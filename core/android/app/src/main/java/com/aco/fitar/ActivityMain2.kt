package com.aco.fitar

import android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.location.Location
import android.os.Build
import android.os.Bundle
import android.os.Handler
import android.util.Log
import android.widget.TextView
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import com.google.android.gms.maps.model.LatLng
import com.google.ar.sceneform.AnchorNode
import com.google.ar.sceneform.Camera
import com.google.ar.sceneform.Scene
import com.google.ar.sceneform.math.Quaternion
import com.google.ar.sceneform.math.Vector3
import com.google.ar.sceneform.rendering.ViewRenderable
import com.google.ar.sceneform.ux.ArFragment
import io.nlopez.smartlocation.SmartLocation
import kotlin.math.*

@RequiresApi(Build.VERSION_CODES.N) class ActivityMain2 : AppCompatActivity(), SensorEventListener {


    private lateinit var camera: Camera
    private lateinit var scene: Scene
    private var azimuth: Int = 0
    private var sensorManager: SensorManager? = null
    private var rotationV: Sensor? = null
    private var accelerometer: Sensor? = null
    private var magnetometer: Sensor? = null
    private var rMat = FloatArray(9)
    private var orientation = FloatArray(3)
    private val lastAccelerometer = FloatArray(3)
    private val lastMagnetometer = FloatArray(3)
    private var lastAccelerometerSet = false
    private var lastMagnetometerSet = false
    private var isArPlaced = false

    override fun onAccuracyChanged(p0: Sensor?, p1: Int) {}
    override fun onSensorChanged(event: SensorEvent) {
        if (event.sensor.type == Sensor.TYPE_ROTATION_VECTOR) {
            SensorManager.getRotationMatrixFromVector(rMat, event.values)
            azimuth = (Math.toDegrees(SensorManager.getOrientation(rMat, orientation)[0].toDouble()) + 360).toInt() % 360
        }

        if (event.sensor.type == Sensor.TYPE_ACCELEROMETER) {
            System.arraycopy(event.values, 0, lastAccelerometer, 0, event.values.size)
            lastAccelerometerSet = true
        } else if (event.sensor.type == Sensor.TYPE_MAGNETIC_FIELD) {
            System.arraycopy(event.values, 0, lastMagnetometer, 0, event.values.size)
            lastMagnetometerSet = true
        }

        if (lastAccelerometerSet && lastMagnetometerSet) {
            SensorManager.getRotationMatrix(rMat, null, lastAccelerometer, lastMagnetometer)
            SensorManager.getOrientation(rMat, orientation)
            azimuth = (Math.toDegrees(SensorManager.getOrientation(rMat, orientation)[0].toDouble()) + 360).toInt() % 360
        }

        if (!isArPlaced) {
            isArPlaced = true
            Handler().postDelayed({
                SmartLocation.with(this).location().start {
                    placeARByLocation(it, LatLng(42.469972,19.294357), "Here we gooo!")
                }
            }, 2000)
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val permissions = arrayOf(android.Manifest.permission.ACCESS_FINE_LOCATION)
        ActivityCompat.requestPermissions(this, permissions,0)

        sensorManager = getSystemService(Context.SENSOR_SERVICE) as SensorManager
        startSensor()
        val arFragment = supportFragmentManager.findFragmentById(R.id.ux_fragment) as ArFragment
        arFragment.planeDiscoveryController.hide()
        arFragment.planeDiscoveryController.setInstructionView(null)
        scene = arFragment.arSceneView.scene!!
        camera = scene.camera

        Log.d("ACO_adding", "created");
    }

    override fun onStart() {
        super.onStart()
        Log.d("ACO_adding", "onStart");

        Handler().postDelayed({
            SmartLocation.with(this).location().start {
                var distance = this.distance(it.latitude, it.longitude, 42.469972,19.294357);
                Log.d("ACO_adding", "distance=${distance}");
            }
        }, 5)
    }

    private fun addPointByXYZ(x: Float, y: Float, z: Float, name: String) {
        ViewRenderable.builder().setView(this, R.layout.arimage).build().thenAccept {

            var textview = it.view.findViewById<TextView>(R.id.note_text)
            textview.text = name;

            Log.d("ACO_adding", "added");
            val node = AnchorNode()
            node.renderable = it
            scene.addChild(node)
            node.worldPosition = Vector3(x, y, z)

            val cameraPosition = scene.camera.worldPosition
            val direction = Vector3.subtract(cameraPosition, node.worldPosition)
            val lookRotation = Quaternion.lookRotation(direction, Vector3.up())
            node.worldRotation = lookRotation
        }
    }

    private fun bearing(locA: Location, locB: Location): Double {
        val latA = locA.latitude * PI / 180
        val lonA = locA.longitude * PI / 180
        val latB = locB.latitude * PI / 180
        val lonB = locB.longitude * PI / 180

        val deltaOmega = ln(tan((latB / 2) + (PI / 4)) / tan((latA / 2) + (PI / 4)))
        val deltaLongitude = abs(lonA - lonB)

        return atan2(deltaLongitude, deltaOmega)
    }

    private fun bearing2(locA:Location, locB: Location):Double{
        val longitude1: Double = locA.longitude
        val longitude2: Double = locB.longitude
        val latitude1 = Math.toRadians(locA.latitude)
        val latitude2 = Math.toRadians(locB.longitude)
        val longDiff = Math.toRadians(longitude2 - longitude1)
        val y = Math.sin(longDiff) * Math.cos(latitude2)
        val x = Math.cos(latitude1) * Math.sin(latitude2) - Math.sin(latitude1) * Math.cos(latitude2) * Math.cos(longDiff)
        return (Math.toDegrees(Math.atan2(y, x)) + 360) % 360
    }

    private fun placeARByLocation(myLocation: Location, targetLocation: LatLng, name: String) {
        val tLocation = Location("")
        tLocation.latitude = targetLocation.latitude
        tLocation.longitude = targetLocation.longitude

        val degree = this.bearing2(myLocation, tLocation);// (azimuth + (bearing2(myLocation, tLocation) * 180 / PI))
        //val distant = 3.0
        val distant = this.distance(myLocation.latitude, myLocation.longitude, targetLocation.latitude, targetLocation.longitude)

        val y = 0.0
        //val x = distant * cos(PI * degree / 180)
        val x = Math.cos(myLocation.latitude)*Math.sin(targetLocation.latitude) - Math.sin(myLocation.longitude)*Math.sin(targetLocation.longitude)
        val z = -1 * 3 * sin(PI * degree / 180)
        //val z = Math.cos(myLocation.latitude)*Math.sin(targetLocation.latitude) - Math.sin(myLocation.longitude)*Math.sin(targetLocation.longitude)
        addPointByXYZ(x.toFloat(), y.toFloat(), z.toFloat(), name)

        Log.d("ARCore_MyLat", myLocation.latitude.toString())
        Log.d("ARCore_MyLon", myLocation.longitude.toString())
        Log.d("ARCore_TargetLat", targetLocation.latitude.toString())
        Log.d("ARCore_TargetLon", targetLocation.longitude.toString())
        Log.d("ARCore_COMPASS", azimuth.toString())
        Log.d("ARCore_Bearmomg", bearing2(myLocation, tLocation).toString())
        Log.d("ARCore_Degree", degree.toString())
        Log.d("ARCore_Distance", distant.toString())
        Log.d("ARCore_X", x.toString())
        Log.d("ARCore_Y", y.toString())
        Log.d("ARCore_Z", z.toString())
        Toast.makeText(this, "Compass: $azimuth, Degree: $degree", Toast.LENGTH_LONG).show()
    }

    private fun startSensor() {
        if (sensorManager!!.getDefaultSensor(Sensor.TYPE_ROTATION_VECTOR) == null) {
            accelerometer = sensorManager!!.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)
            magnetometer = sensorManager!!.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD)
            sensorManager!!.registerListener(this, accelerometer, SensorManager.SENSOR_DELAY_UI)
            sensorManager!!.registerListener(this, magnetometer, SensorManager.SENSOR_DELAY_UI)
        } else {
            rotationV = sensorManager!!.getDefaultSensor(Sensor.TYPE_ROTATION_VECTOR)
            sensorManager!!.registerListener(this, rotationV, SensorManager.SENSOR_DELAY_UI)
        }
    }

    private fun stopSensor() {
        sensorManager!!.unregisterListener(this, accelerometer)
        sensorManager!!.unregisterListener(this, magnetometer)
    }

    override fun onPause() {
        super.onPause()
        stopSensor()
    }

    override fun onResume() {
        super.onResume()
        startSensor()
    }

    private fun distance( lat1: Double, lon1: Double, lat2: Double, lon2: Double ): Double {
        val earthRadius = 6371000.0 //meters

        val dLat = Math.toRadians(lat2 - lat1)
        val dLng = Math.toRadians(lon1 - lon2)
        val a = Math.sin(dLat / 2) * Math.sin(dLat / 2) + Math.cos(Math.toRadians(lat1)) * Math.cos( Math.toRadians(lat2)) * Math.sin(dLng / 2) * Math.sin(dLng / 2)
        val c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a))
        val dist = (earthRadius * c).toFloat()

        return dist.toDouble()
    }

}