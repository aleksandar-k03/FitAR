package com.aco.fitar.api.controllers

import com.aco.fitar.api.ControllerBase
import com.aco.fitar.api.models.AnchorModel
import com.aco.fitar.api.models.AnchorResponseModel
import com.aco.fitar.api.models.LoginModel
import com.aco.fitar.api.models.LoginResponse

class AnchorController : ControllerBase<AnchorModel, AnchorResponseModel>() {

    override val authorization: Boolean get() = false;
    override val endpoint: String get() = "anchor";

    public fun call(model:AnchorModel, callback:(AnchorResponseModel)->Unit){
        this.post<AnchorResponseModel>("", model, AnchorResponseModel::class.java, callback);
    }

}