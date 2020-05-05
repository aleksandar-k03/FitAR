package com.aco.fitar.api

import kotlinx.serialization.Serializable
import java.lang.reflect.ParameterizedType

@Serializable
abstract class ModelBase {

}

@Serializable
abstract  class ModelResponseBase{
    public var errorMessage:String = "";
    public var hasError:Boolean = false;

    companion object{
        public fun<T> generateError(err:String, type:Class<T>):T where T: ModelResponseBase{
            var respones = type.newInstance();
            respones.hasError = true;
            respones.errorMessage = err;
            return respones;
        }
    }
}

class DefaultModelResponse : ModelResponseBase(){ }