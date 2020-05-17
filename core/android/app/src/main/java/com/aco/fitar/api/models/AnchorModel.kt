package com.aco.fitar.api.models

import com.aco.fitar.api.ModelResponseBase
import kotlinx.serialization.Serializable

@Serializable
class AnchorModel(var sessionid:String, var anchorid:String, var lat:Double, var lng:Double, var noteText:String) {
}

@Serializable
class AnchorResponseModel : ModelResponseBase() {
}

@Serializable
class AnchorResponse {
    public var id:String = "";
    public var username:String = "";
    public var text:String = "";
}