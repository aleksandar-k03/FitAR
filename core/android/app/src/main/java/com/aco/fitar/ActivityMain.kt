package com.aco.fitar

import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import com.aco.fitar.api.controllers.AnchorController
import com.aco.fitar.api.models.AnchorModel
import com.aco.fitar.api.models.LoginResponse
import com.aco.fitar.core.*
import com.aco.fitar.sockets.ARSocket
import com.google.ar.core.Config
import com.google.ar.sceneform.ArSceneView
import com.google.ar.sceneform.Scene
import com.microsoft.CloudServices
import com.microsoft.azure.spatialanchors.*
import io.nlopez.smartlocation.SmartLocation
import java.util.*


class ActivityMain : ActivityBase(){

    private lateinit var btnMain:ImageView
    private lateinit var azureScene: AzureSpatialAnchorsManager
    private lateinit var arFragment: ARImageFragment
    private lateinit var arSceneView:ArSceneView
    private lateinit var loginInfo: LoginResponse
    private lateinit var socket:ARSocket;
    private var locationProvider: PlatformLocationProvider? = null
    private var isScanned:Boolean = true
    private var recommendedForCreateProgress:Float = 0f
    private var requiredForCreateProgress:Float = 0f
    private var syncSessionProgress:Object = Object()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        CloudServices.initialize(this);
        this.loginInfo = ModelPreferencesManager.get<LoginResponse>("login")!!;
        this.socket = ARSocket(this, this.loginInfo)
        socket.init()

        this.setContentView(R.layout.activity_main);

        this.arFragment = supportFragmentManager.findFragmentById(R.id.ux_fragment) as ARImageFragment;
        this.arSceneView = this.arFragment.arSceneView
        this.arSceneView.scene.addOnUpdateListener(Scene.OnUpdateListener {
            if(this.azureScene.spatialAnchorsSession != null)
                this.azureScene.update(arSceneView.arFrame)
                //this.azureScene.spatialAnchorsSession.processFrame(this.arSceneView.arFrame);
        })
        this.initializeSessionForSceneView()

        var azureStatsu:TextView = findViewById(R.id.anchor_status)
        azureScene = AzureSpatialAnchorsManager(this.arSceneView.session)
        azureScene.addSessionUpdatedListener({
            recommendedForCreateProgress = it.getStatus().getRecommendedForCreateProgress()
            requiredForCreateProgress = it.getStatus().getReadyForCreateProgress();
            runOnUiThread({
                azureStatsu.text = "Скенирање околине: " + (requiredForCreateProgress * 100).toInt() + "% /" + (recommendedForCreateProgress * 100).toInt();
                if(requiredForCreateProgress >= .2){
                    azureStatsu.visibility = View.GONE
                    isScanned = true;
                }
            })

        });

        this.azureScene.addAnchorLocatedListener(AnchorLocatedListener {
            var identifier = it.identifier;
            when(it.status){
                LocateAnchorStatus.Located -> {

                }
                LocateAnchorStatus.NotLocated -> {}
                LocateAnchorStatus.AlreadyTracked -> {}
                LocateAnchorStatus.NotLocatedAnchorDoesNotExist -> {}
            }
        })

        this.arOnTap()
    }

    override fun onResume() {
        super.onResume()
        SensorPermissionsHelper.requestMissingPermissions( this, 1)

        locationProvider = PlatformLocationProvider()
        locationProvider!!.sensors.knownBeaconProximityUuids = AzureSpatialAnchorsManager.KNOWN_BLUETOOTH_PROXIMITY_UUIDS
        SensorPermissionsHelper.enableAllowedSensors(this, locationProvider)

        this.azureScene.setLocationProvider(locationProvider!!)
        this.azureScene.start()
    }

    override fun onStop() {
        super.onStop()

        if (this.azureScene != null)
            this.azureScene.stop()
        locationProvider = null
    }

    private fun initializeSessionForSceneView(){
        try{
            var session = com.google.ar.core.Session(this)
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
            anchorBeingCreated = ARView(this.arFragment, this.loginInfo.username, this.loginInfo.profilePix, azureAncor)
            anchorBeingCreated.render()

            var dialog = DialogSaveNote(this);
            dialog.onCancel = { this.anchorBeingCreated.destroy(); };

            dialog.onSave = {
                var noteText = it
                this.anchorBeingCreated.setText(it);
                Log.d("control", " sending to azure");
                Thread(Runnable {

                    do
                    {
                        runOnUiThread({ anchorBeingCreated.statusText.text = (recommendedForCreateProgress * 100).toInt().toString() + "%" });
                        Thread.sleep(500)
                    }
                    while (recommendedForCreateProgress <= 1.0)
                    runOnUiThread({
                        anchorBeingCreated.statusText.text = "100%"
                        anchorBeingCreated.statusImg.setImageResource(R.drawable.circle_green);
                    })

                    this.azureScene.uploadCloudAnchorAsync(azureAncor).thenAccept({
                        var anchorID = it;
                        Log.d("control", "anchor created: " + anchorID);
                        SmartLocation.with(this).location().start {
                            Log.d("control", "locatio created: " +  it.toString());
                            var model = AnchorModel(this.loginInfo.session, anchorID, it.latitude.toDouble(), it.longitude.toDouble(), noteText);
                            AnchorController().call(model, {

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

    override fun onRequestPermissionsResult( requestCode: Int, permissions: Array<out String>, grantResults: IntArray ) {
        if (requestCode == 1) {
            if (!SensorPermissionsHelper.hasAllRequiredPermissionGranted(this)) {
                Toast.makeText(
                    this,
                    "Location permission is needed to run this demo",
                    Toast.LENGTH_LONG
                )
                    .show()
                finish()
            } else if (locationProvider != null) {
                SensorPermissionsHelper.enableAllowedSensors(this, locationProvider)
            }
        }
    }


}


