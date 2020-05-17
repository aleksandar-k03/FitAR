package com.aco.fitar.core

import android.app.Application
import android.content.Context
import android.content.SharedPreferences
import com.google.gson.GsonBuilder

object ModelPreferencesManager {

    var isInstantiated:Boolean = false;
    lateinit var preferences: SharedPreferences
    public const val PREFERENCES_NAME = "AR_APLIKACIJA"

    fun with(application: Application) {
        preferences = application.getSharedPreferences(PREFERENCES_NAME, Context.MODE_PRIVATE)
        this.isInstantiated = true;
    }

    fun <T> put(`object`: T, key: String) {
        val jsonString = GsonBuilder().create().toJson(`object`)
        preferences.edit().putString(key, jsonString).apply()
    }

    inline fun <reified T> get(key: String): T? {
        val value = preferences.getString(key, null)
        if(value == null)
            return null;
        return GsonBuilder().create().fromJson(value, T::class.java)
    }
}