package com.aco.fitar

import android.util.Log
import android.widget.Toast
import com.aco.fitar.api.controllers.AnchorController
import com.aco.fitar.api.models.AnchorModel
import com.aco.fitar.api.models.AnchorResponse
import com.aco.fitar.core.ARImageFragment
import com.aco.fitar.core.AzureSpatialAnchorsManager
import com.google.ar.core.Config
import com.google.ar.sceneform.ArSceneView
import com.google.ar.sceneform.Scene
import com.microsoft.appcenter.utils.HandlerUtils.runOnUiThread
import com.microsoft.azure.spatialanchors.*
import io.nlopez.smartlocation.SmartLocation

class ActivityMainARManager(var context: ActivityMain) {

    public lateinit var azureScene: AzureSpatialAnchorsManager
    public lateinit var arFragment: ARImageFragment
    public lateinit var arSceneView: ArSceneView
    private var reccommendedScanningProcess:Float = 0f
    private var currentScanningProcess:Float = 0f
    private var isScanned:Boolean = true
    private lateinit var anchorsFromDatabase:Array<AnchorResponse>
    private lateinit var anchorsList:ArrayList<String>
    private var anchorLocationListener:AnchorLocatedListener? = null

    public fun init(){
        this.arFragment = context.supportFragmentManager.findFragmentById(R.id.ux_fragment) as ARImageFragment;
        this.arSceneView = this.arFragment.arSceneView
        this.arSceneView.scene.addOnUpdateListener(Scene.OnUpdateListener {
            if(this.azureScene.spatialAnchorsSession != null)
                this.azureScene.update(arSceneView.arFrame)
            //this.azureScene.spatialAnchorsSession.processFrame(this.arSceneView.arFrame);
        });
        this.initializeSessionForSceneView();

        azureScene = AzureSpatialAnchorsManager(this.arSceneView.session)

        AnchorController().getAll {
            Log.d("contol", "received -> " + it.toString() )
            this.anchorsFromDatabase = it;
            context.notifications.addNotification("Претходне поруке су учитане", NotificationType.green);
            ////context.runOnUiThread({ Toast.makeText(context, "Ucitani su idevi", Toast.LENGTH_LONG).show(); })

            this.anchorsList = ArrayList()
            it.forEach { this.anchorsList.add(it.id) }

            if(this.currentScanningProcess < .4f || this.currentScanningProcess != this.reccommendedScanningProcess)
                return@getAll;

            this.addAnchors()
        }
        this.azureScene.addLocateAnchorsCompletedListener({ event: LocateAnchorsCompletedEvent? ->
            ////context.runOnUiThread({ Toast.makeText(context, "Anchor located ", Toast.LENGTH_LONG).show(); })
        })
        this.onSessionUpdate()
        this.addAnchorLocatedListener()
        this.arOnTap()
    }

    public fun onStop(){
        if (this.azureScene != null)
        {
            this.azureScene.stop()
        }

    }

    // dodaj jedan ID
    public fun addAnchor(data:String){
        this.anchorsList.add(data);
        this.addAnchors();
    }

    /// dodaj listu id-eva
    private var anchorsAdded:Boolean = false;
    public fun addAnchors(force:Boolean = false){
        if((!force && anchorsAdded) || ::anchorsList.isInitialized == false || this.anchorsList.count() == 0)
            return;

        if(this.anchorLocationListener != null){
            this.azureScene.removeAnchorLocatedListener(this.anchorLocationListener);
            this.anchorLocationListener = null;
        }

        if(this.azureScene.isLocating)
            this.azureScene.stopLocating()

        this.azureScene.stop();
        this.anchorsAdded = true;
        this.azureScene.stopLocating();
        val criteria = AnchorLocateCriteria()
        /*
        val nearDevice = NearDeviceCriteria()
        nearDevice.distanceInMeters = 8.0f
        nearDevice.maxResultCount = 25
        criteria.nearDevice = nearDevice
        */
        criteria.identifiers = this.anchorsList.toTypedArray()

        this.azureScene.start();
        var watcher:CloudSpatialAnchorWatcher = this.azureScene.startLocating(criteria)

        context.notifications.addNotification("Скенирање започето са порукама са сервера", NotificationType.green)
        ////context.runOnUiThread({ Toast.makeText(context, "Dodati su idevi", Toast.LENGTH_LONG).show(); })
        Log.d("Control", "added into watcher " + this.anchorsList.toString())
    }

    public fun onResume(){
        this.azureScene.setLocationProvider(context.locationProvider!!)
        this.azureScene.start()

    }

    private fun onSessionUpdate(){
        azureScene.addSessionUpdatedListener({
            reccommendedScanningProcess = it.getStatus().getRecommendedForCreateProgress()
            currentScanningProcess = it.getStatus().getReadyForCreateProgress();
            context.runOnUiThread({
                context.azureStatsu.text = "Скенирање околине: " + (currentScanningProcess * 100).toInt() + "% / " + (reccommendedScanningProcess * 100).toInt() + "%";
                if(currentScanningProcess >= .4f && this.anchorsAdded == false && this.anchorsList != null)
                    this.addAnchors();
                if(currentScanningProcess >= 1){
                    this.addAnchors()
                    context.azureStatsu.alpha = .5f;
                    isScanned = true;
                }
                else{
                    context.azureStatsu.alpha = 1f;
                }
            })

        });
    }

    private fun addAnchorLocatedListener(){
        this.azureScene.addAnchorLocatedListener(AnchorLocatedListener {
            context.runOnUiThread({
                var identifier = it.identifier;
                //context.runOnUiThread({ Toast.makeText(context, "id:" + identifier, Toast.LENGTH_LONG).show(); })
                when(it.status){
                    LocateAnchorStatus.Located -> {
                        context.runOnUiThread({

                            Log.d("Control", "Prepoznat ID " + identifier)
                            //context.runOnUiThread({ Toast.makeText(context, "Prepoznat id:" + identifier, Toast.LENGTH_LONG).show(); })

                            // Get the note, which we stored as a property on the CloudSpatialAnchor.
                            val properties: Map<String, String> = it.anchor.getAppProperties()
                            var username:String = ""
                            var text:String = "";

                            if(properties.containsKey("username")) username = properties.get("username")!! // za svaki slucaj
                            if(properties.containsKey("text")) text = properties.get("text")!!;

                            this.anchorsFromDatabase.forEach {
                                if(it.id == identifier){
                                    username = it.username;
                                    text = it.text
                                }
                            }

                            var azureAncor = it.anchor
                            var anchorView = ARView(this.arFragment, azureAncor)
                            anchorView.defaultText = text
                            anchorView.defaultUsername = username
                            anchorView.hideAdditionalInformations = true

                            anchorView.render()
                        });
                    }
                    LocateAnchorStatus.NotLocated -> {
                        //context.runOnUiThread({ Toast.makeText(context, "NotLocated:" + identifier, Toast.LENGTH_LONG).show(); })
                    }
                    LocateAnchorStatus.AlreadyTracked -> {
                        //context.runOnUiThread({ Toast.makeText(context, "AlreadyTracked:" + identifier, Toast.LENGTH_LONG).show(); })
                    }
                    LocateAnchorStatus.NotLocatedAnchorDoesNotExist -> {
                        //context.runOnUiThread({ Toast.makeText(context, "NotLocatedAnchorDoesNotExist:" + identifier, Toast.LENGTH_LONG).show(); })
                    }
                }
            })
        })
    }

    private fun initializeSessionForSceneView(){
        try{
            var session = com.google.ar.core.Session(context)
            var config = com.google.ar.core.Config(session);
            config.setUpdateMode(Config.UpdateMode.LATEST_CAMERA_IMAGE)
            session.configure(config);
            this.arFragment.arSceneView.setupSession(session);
        }
        catch (e:Exception){

        }
    }

    private lateinit var anchorBeingCreated:ARView
    private fun arOnTap(){
        this.arFragment.setOnTapArPlaneListener { hitResult, plane, motionEvent ->
            if(isScanned == false)
                return@setOnTapArPlaneListener;

            var azureAncor = CloudSpatialAnchor()
            azureAncor.localAnchor = hitResult.createAnchor()
            azureAncor.appProperties.set("username", context.loginInfo.username);
            anchorBeingCreated = ARView(this.arFragment, azureAncor)
            anchorBeingCreated.defaultUsername = context.loginInfo.username
            anchorBeingCreated.render()

            var dialog = DialogSaveNote(context);
            dialog.onCancel = { this.anchorBeingCreated.destroy(); };

            dialog.onSave = {
                var noteText = it
                this.anchorBeingCreated.setText(it);
                Log.d("control", " sending to azure");
                Thread(Runnable {

                    do
                    {
                        runOnUiThread({ anchorBeingCreated.statusText.text = (reccommendedScanningProcess * 100).toInt().toString() + "%" });
                        Thread.sleep(500)
                    }
                    while (reccommendedScanningProcess <= 1.0)
                    runOnUiThread({
                        anchorBeingCreated.statusText.text = "100%"
                        anchorBeingCreated.statusImg.setImageResource(R.drawable.circle_green);
                    })

                    azureAncor.appProperties.set("text", noteText);
                    this.azureScene.uploadCloudAnchorAsync(azureAncor).thenAccept({
                        var anchorID = it;
                        Log.d("control", "anchor created: " + anchorID);
                        //context.runOnUiThread({ Toast.makeText(context, "Kreiran acnhro ID: " + anchorID, Toast.LENGTH_LONG).show(); })
                        SmartLocation.with(context).location().start {
                            Log.d("control", "location created: " +  it.toString());
                            var model = AnchorModel(context.loginInfo.session, anchorID, it.latitude, it.longitude, noteText);
                            AnchorController().call(model, {
                                if(!it.hasError) return@call;
                                context.runOnUiThread({
                                    context.notifications.addNotification("Грешка у чувању поруке", NotificationType.red)
                                    //Toast.makeText(context, "Greska u postavljanju!: " + anchorID, Toast.LENGTH_LONG).show();
                                    anchorBeingCreated.destroy();
                                })
                            });

                        }
                    }).exceptionally( {
                        runOnUiThread({ anchorBeingCreated.destroy() })
                        Log.d("control error", it.message.toString());
                        it.printStackTrace()
                        null;
                    })

                }).start()
            };
            dialog.show();
        }
    }

}