package com.aco.fitar.api.models
import kotlinx.serialization.*


import com.aco.fitar.api.ModelBase
import com.aco.fitar.api.ModelResponseBase

@Serializable
class LoginModel(var username:String, var password:String) : ModelBase() {

}

@Serializable
class LoginResponse : ModelResponseBase() {
    public var clientID:Int = 0;
    public var session:String="";
    public var password:String="";

    public var username:String="";
    public var firstName:String="";
    public var lastName:String="";
    public var profilePic:String="";

}