package com.aco.fitar.sockets

import android.location.Location
import android.os.Handler
import android.os.Looper
import android.util.Log
import com.aco.fitar.ActivityMain
import com.aco.fitar.NotificationDuration
import com.aco.fitar.NotificationType
import com.aco.fitar.api.ApiManager
import com.aco.fitar.api.models.LoginResponse
import com.aco.fitar.sockets.models.SocketModelBase
import com.aco.fitar.sockets.models.SocketTextMessage
import com.google.gson.Gson
import io.nlopez.smartlocation.SmartLocation
import okhttp3.*
import okio.ByteString
import java.util.concurrent.TimeUnit


class ARSocket(var activity:ActivityMain, var login:LoginResponse) : WebSocketListener() {

    public var isConnected:Boolean = false
    private lateinit var onConnect:()->Unit;
    private lateinit var onDisconnect:()->Unit;
    private var lastLocation: Location? = null
    private var webSocket:WebSocket? = null

    public fun init(){
        SocketHttpsFix.Fix();

        val client = SocketHttpsFix.getUnsafeOkHttpClient()
            .readTimeout(15, TimeUnit.SECONDS)
            .build()
        val request = Request.Builder()
            .url(ApiManager.socket + this.login.session)
            .build()
        this.webSocket = client.newWebSocket(request, this)
    }

    override fun onOpen(webSocket: WebSocket, response: Response) {
        // slanje lokacije klijenta svakih 15 sekundi
        val gson = Gson()
        val mainHandler = Handler(Looper.getMainLooper())
        activity.notifications.addNotification("Сокет је повезан")
        mainHandler.post(object : Runnable {
            override fun run() {
                SmartLocation.with(activity).location().start {
                   if(lastLocation != null && distance(it.latitude, it.longitude, lastLocation!!.latitude, lastLocation!!.longitude) <= 15)
                       return@start;

                    var pingModel = PingModel(it.latitude, it.longitude);
                    webSocket.send("ping#" + gson.toJson(pingModel));
                }
                mainHandler.postDelayed(this, 15 * 1000 * 1000)
            }
        })
    }

    override fun onMessage(webSocket: WebSocket?, text: String?) {
        output("Receiving : " + text!!)
        val gson = Gson()
        var received:SocketModelBase = gson.fromJson<SocketModelBase>(text!!, SocketModelBase::class.java);

        when(received.action){
            // dobijanje standardnih notifikacija
            "text" -> {
                var model = gson.fromJson<SocketTextMessage>(received.data, SocketTextMessage::class.java);
                activity.notifications.addNotification(model.text)
            }
        }
    }

    override fun onMessage(webSocket: WebSocket?, bytes: ByteString?) {
        output("Receiving bytes : " + bytes!!.hex())
    }

    override fun onClosing(webSocket: WebSocket?, code: Int, reason: String?) {
        webSocket!!.close(NORMAL_CLOSURE_STATUS, null)
        activity.notifications.addNotification("Сокет је затвара", NotificationType.red, NotificationDuration.long)
        output("Closing : $code / $reason")
    }

    override fun onFailure(webSocket: WebSocket, t: Throwable, response: Response?) {
        super.onFailure(webSocket, t, response)
        activity.notifications.addNotification("Грешка у повезивању са сокетом", NotificationType.red, NotificationDuration.long)

        Log.d("SOCKET", "error: " +  t.message.toString())
    }

    companion object {
        private val NORMAL_CLOSURE_STATUS = 1000
    }

    private fun output(txt: String) {
        Log.v("WSS", txt)
    }

    public fun destroy(){
        this.webSocket?.close(1000, "destroy")
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