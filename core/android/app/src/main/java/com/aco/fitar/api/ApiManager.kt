package com.aco.fitar.api

import android.content.Context
import com.aco.fitar.sockets.SocketHttpsFix
import com.androidnetworking.AndroidNetworking

object ApiManager {

    //private val host:String = "ccmonkeysbot-fitar.azurewebsites.net";
    private val host:String = "192.168.1.10:5001";
    public val endpoint:String = "https://${host}/api/";
    public val socket:String = "wss://${host}/ws_droid?id=";

    public fun init(context: Context){
        SocketHttpsFix.disableSSLCertificateChecking();
        AndroidNetworking.initialize(context.getApplicationContext());
    }
}