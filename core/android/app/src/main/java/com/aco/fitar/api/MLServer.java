package com.aco.fitar.api;

import android.util.Log;

import com.aco.fitar.api.ApiManager;
import com.aco.fitar.sockets.SocketHttpsFix;
import com.google.android.gms.common.api.internal.BaseImplementation;

import org.jetbrains.annotations.NotNull;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.IOException;
import java.util.Collections;
import java.util.concurrent.TimeUnit;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.CipherSuite;
import okhttp3.ConnectionSpec;
import okhttp3.MediaType;
import okhttp3.MultipartBody;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;
import okhttp3.TlsVersion;


public class MLServer {

    private static final String TAG = "MLSERVER";
    private static final MediaType MEDIA_TYPE_PNG = MediaType.parse("image/png");

    public static OkHttpClient getClient(){
        return
                SocketHttpsFix.getUnsafeOkHttpClient()
                        .connectionSpecs(Collections.singletonList(getSpecs()))
                        .connectTimeout(60, TimeUnit.HOURS)
                        .writeTimeout(60, TimeUnit.HOURS)
                        .readTimeout(60, TimeUnit.HOURS)
                        .build();
    }

    public static void SendImage(SendImageCallback callback){
        try {

            OkHttpClient client = getClient();

            RequestBody requestBody = new MultipartBody.Builder().setType(MultipartBody.FORM)
                    .addFormDataPart("file", "a.jpg", RequestBody.create(MEDIA_TYPE_PNG, new File(callback.fileLocation)))
                    .build();

            String endpoint = ApiManager._endpoint;
            Request request = new Request.Builder().url(com.aco.fitar.api.ApiManager._endpoint +  "profilepic/?username=" + callback.username)
                    .post(requestBody).build();

            Log.d("API", "before send");
            client.newCall(request).enqueue(new Callback() {
                @Override
                public void onFailure(@NotNull Call call, @NotNull IOException e) {
                    Log.d(TAG, e.toString());
                    e.printStackTrace();
                    callback.onError(e.toString());
                }

                @Override
                public void onResponse(@NotNull Call call, @NotNull Response response) throws IOException {
                    String responseTxt = response.body().string();
                    Log.d(TAG, "response:: " + responseTxt);
                    callback.onSuccess();
                }
            });


        }
        catch (Exception e){
            e.printStackTrace();
            callback.onError(e.toString());
        }
    }

    private static ConnectionSpec getSpecs(){
        return new ConnectionSpec.Builder(ConnectionSpec.COMPATIBLE_TLS)
                .supportsTlsExtensions(true)
                .tlsVersions(TlsVersion.TLS_1_2, TlsVersion.TLS_1_1, TlsVersion.TLS_1_0)
                .cipherSuites(
                        CipherSuite.TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256,
                        CipherSuite.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256,
                        CipherSuite.TLS_DHE_RSA_WITH_AES_128_GCM_SHA256,
                        CipherSuite.TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA,
                        CipherSuite.TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA,
                        CipherSuite.TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA,
                        CipherSuite.TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA,
                        CipherSuite.TLS_ECDHE_ECDSA_WITH_RC4_128_SHA,
                        CipherSuite.TLS_ECDHE_RSA_WITH_RC4_128_SHA,
                        CipherSuite.TLS_DHE_RSA_WITH_AES_128_CBC_SHA,
                        CipherSuite.TLS_DHE_DSS_WITH_AES_128_CBC_SHA,
                        CipherSuite.TLS_DHE_RSA_WITH_AES_256_CBC_SHA)
                .build();
    }



}