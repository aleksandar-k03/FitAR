package com.aco.fitar

import android.animation.Animator
import android.animation.Animator.AnimatorListener
import android.app.Activity
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.view.View
import android.view.ViewAnimationUtils
import android.view.ViewTreeObserver
import android.view.ViewTreeObserver.OnGlobalLayoutListener
import android.view.animation.AccelerateInterpolator
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.core.app.ActivityCompat
import androidx.core.app.ActivityOptionsCompat
import com.aco.fitar.api.models.AnchorResponse
import com.aco.fitar.api.models.LoginResponse
import com.aco.fitar.core.ActivityBase
import com.aco.fitar.core.AzureSpatialAnchorsManager
import com.aco.fitar.core.ModelPreferencesManager
import com.aco.fitar.core.SensorPermissionsHelper
import com.aco.fitar.sockets.ARSocket
import com.microsoft.CloudServices
import com.microsoft.azure.spatialanchors.PlatformLocationProvider


class ActivityMain : ActivityBase(){

    companion object{
        var IS_CLOUD_SESSION_INITILIZED:Boolean = false
    }

    public lateinit var btnMain:ImageView
    public lateinit var arManager:ActivityMainARManager
    public lateinit var drawer: ActivityMainDrawer
    public lateinit var notifications:ActivityMainNotifications
    public lateinit var loginInfo: LoginResponse
    public lateinit var socket:ARSocket;
    public var locationProvider: PlatformLocationProvider? = null
    public lateinit var azureStatsu:TextView
    public lateinit var anchorsFromDatabase:Array<AnchorResponse>



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        if(IS_CLOUD_SESSION_INITILIZED == false)
        {
            CloudServices.initialize(this);
            IS_CLOUD_SESSION_INITILIZED = true
        }
        this.setContentView(R.layout.activity_main);

        this.drawer = ActivityMainDrawer(this);
        this.notifications = ActivityMainNotifications(this);
        this.loginInfo = ModelPreferencesManager.get<LoginResponse>("login")!!;
        this.socket = ARSocket(this, this.loginInfo)
        this.arManager = ActivityMainARManager(this)



        azureStatsu = findViewById(R.id.anchor_status)

        this.arManager.init()
        this.drawer.init();
        this.notifications.init()
        socket.init()
    }

    override fun onResume() {
        super.onResume()

        SensorPermissionsHelper.requestMissingPermissions( this, 1)
        locationProvider = PlatformLocationProvider()
        locationProvider!!.sensors.knownBeaconProximityUuids = AzureSpatialAnchorsManager.KNOWN_BLUETOOTH_PROXIMITY_UUIDS
        SensorPermissionsHelper.enableAllowedSensors(this, locationProvider)

        this.arManager.onResume()
    }

    override fun onStop() {
        super.onStop()
        this.arManager.onStop();
        locationProvider = null
    }




    override fun onRequestPermissionsResult( requestCode: Int, permissions: Array<out String>, grantResults: IntArray ) {
        if (requestCode == 1) {
            if (!SensorPermissionsHelper.hasAllRequiredPermissionGranted(this)) {
                Toast.makeText(
                    this,
                    "Дозвола за локацију је потребна!!!",
                    Toast.LENGTH_LONG
                )
                    .show()
                finish()
            } else if (locationProvider != null) {
                SensorPermissionsHelper.enableAllowedSensors(this, locationProvider)
            }
        }
    }

    override fun onDestroy() {
        this.socket.destroy()
        super.onDestroy()
    }

    override fun onBackPressed() {
        ActivityCompat.finishAffinity(this)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (resultCode == Activity.RESULT_OK && requestCode == 25) {
            // I'M GETTING THE URI OF THE IMAGE AS DATA AND SETTING IT TO THE IMAGEVIEW
            this.drawer.onImage(data?.data.toString())
        }
    }

}


