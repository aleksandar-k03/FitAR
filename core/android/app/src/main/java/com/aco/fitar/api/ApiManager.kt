package com.aco.fitar.api

import android.content.Context
import com.aco.fitar.sockets.SocketHttpsFix
import com.androidnetworking.AndroidNetworking

public object ApiManager {


    lateinit var _endpoint: String

    //private val host:String = "ccmonkeysbot-fitar.azurewebsites.net";
    public var host:String = "192.168.1.10:5001";
    public var endpoint:String = "https://${host}/api/";
    public var socket:String = "wss://${host}/ws_droid?id=";

    public fun init(context: Context){
        SocketHttpsFix.disableSSLCertificateChecking();
        AndroidNetworking.initialize(context.getApplicationContext());

        _endpoint = endpoint
    }
}