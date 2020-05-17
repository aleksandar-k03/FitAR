package com.aco.fitar.api.controllers

import com.aco.fitar.api.ControllerBase
import com.aco.fitar.api.models.*
import com.google.gson.Gson
import kotlin.Array as Array

class AnchorController : ControllerBase<AnchorModel, AnchorResponseModel>() {

    override val authorization: Boolean get() = false;
    override val endpoint: String get() = "anchor";

    public fun call(model:AnchorModel, callback:(AnchorResponseModel)->Unit){
        this.post<AnchorResponseModel>("", model, AnchorResponseModel::class.java, callback);
    }

    public fun getAll(callback:(Array<AnchorResponse>) -> Unit){
        val gson = Gson()
        this.getMultiple("getAll", null, callback = {
            callback(gson.fromJson<Array<AnchorResponse>>(it, Array<AnchorResponse>::class.java));
        });
    }

}