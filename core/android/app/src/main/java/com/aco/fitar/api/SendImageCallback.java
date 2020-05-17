package com.aco.fitar.api;

public class SendImageCallback {
    public String fileLocation= "";
    public String username= "";

    public SendImageCallback(String username,String fileLocation){
        this.fileLocation = fileLocation;
        this.username = username;
    }

    public void onSuccess(){}
    public void onError(String reason){}
}
