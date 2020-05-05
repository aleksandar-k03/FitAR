package com.aco.fitar.api.controllers

import android.text.Editable
import com.aco.fitar.api.ControllerBase
import com.aco.fitar.api.models.LoginModel
import com.aco.fitar.api.models.LoginResponse

class LoginController : ControllerBase<LoginModel, LoginResponse>() {

    override val authorization: Boolean get() = false;
    override val endpoint: String get() = "login";

    public fun call(username: String, password: String, callback:(LoginResponse)->Unit){
        this.post<LoginResponse>("", LoginModel(username, password), LoginResponse::class.java, callback);
    }

}