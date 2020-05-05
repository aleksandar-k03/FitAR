package com.aco.fitar.api.models

import com.aco.fitar.api.ModelBase
import com.aco.fitar.api.ModelResponseBase

class RegistrationModel(var username:String, var firstName:String, var lastName:String, var password:String) : ModelBase() {

}

class RegistrationResponseModel: ModelResponseBase(){}