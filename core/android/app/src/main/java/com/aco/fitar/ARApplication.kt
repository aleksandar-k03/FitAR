package com.aco.fitar

import android.app.Application
import com.aco.fitar.core.ModelPreferencesManager

class ARApplication : Application() {

    override fun onCreate() {
        super.onCreate()
        ModelPreferencesManager.with(this);

    }

}