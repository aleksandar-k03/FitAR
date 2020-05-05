package com.aco.fitar.api.controllers

import com.aco.fitar.api.ControllerBase
import com.aco.fitar.api.models.RegistrationModel
import com.aco.fitar.api.models.RegistrationResponseModel

class RegistrationController : ControllerBase<RegistrationModel, RegistrationResponseModel>() {

    override val authorization: Boolean get() = false
    override val endpoint: String get() = "registration"

    public fun call(username:String, firstName:String, lastName:String, password:String, callback:(RegistrationResponseModel)->Unit){
        this.post<RegistrationResponseModel>("create", RegistrationModel(username, firstName, lastName, password), RegistrationResponseModel::class.java, callback);
    }
}