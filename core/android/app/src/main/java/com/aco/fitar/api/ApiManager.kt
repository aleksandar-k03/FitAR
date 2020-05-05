package com.aco.fitar.api

import android.content.Context
import com.androidnetworking.AndroidNetworking

class ApiManager {
    companion object{
        public val endpoint:String = "https://ccmonkeysbot-fitar.azurewebsites.net/api/";

        public fun init(context: Context){
            AndroidNetworking.initialize(context.getApplicationContext());
        }

    }
}