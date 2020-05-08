package com.aco.fitar.api

import android.util.Log
import com.androidnetworking.AndroidNetworking
import com.androidnetworking.error.ANError
import com.androidnetworking.interfaces.JSONObjectRequestListener
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import kotlinx.serialization.json.Json
import kotlinx.serialization.json.JsonConfiguration
import org.json.JSONObject


abstract class ControllerBase<TModel, TOutput>
{

    abstract val authorization:Boolean;
    abstract val endpoint:String;

    open fun <T> toObject(jsonStr: String?, cls: Class<T>?): T? {
        if (jsonStr == null) return null
        val gson = Gson()
        return gson.fromJson(jsonStr, cls)
    }

    public inline fun <reified TOutput> post(action:String, model:TModel,
                                             responseClass:Class<TOutput>,
                                             crossinline callback:(TOutput)->Unit)
        where TOutput : ModelResponseBase
    {
        val gson = Gson()
        Log.d("ControllerBase", "Calling action ${ApiManager.endpoint}${this.endpoint}/${action}, with data:${gson.toJson(model)}")
        var net = AndroidNetworking.post(ApiManager.endpoint + this.endpoint + "/" + action);
        net.addBodyParameter(model);
        val json = Json(JsonConfiguration.Stable)

        net.build().getAsJSONObject(object : JSONObjectRequestListener {
            override fun onResponse(response: JSONObject) {
                Log.d("ControllerBase", "Response ${response.toString()}")
                var result:TOutput = gson.fromJson<TOutput>(response.toString(), TOutput::class.java);
                callback(result)
            }

            override fun onError(error: ANError) {
                Log.d("ControllerBase", "Error ${error.toString()}")
                var result:TOutput = responseClass.newInstance()
                result.hasError = true;
                result.errorMessage = "Системска грешка у комуникацији са сервером";
                callback(result);
            }
        });
    }

}