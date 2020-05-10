package com.aco.fitar.core

import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.FrameLayout
import com.aco.fitar.R
import com.google.ar.core.AugmentedImageDatabase
import com.google.ar.core.Config
import com.google.ar.core.Session
import com.google.ar.sceneform.ux.ArFragment

class ARImageFragment : ArFragment(){

    override fun getSessionConfiguration(session: Session?): Config {
        var config:Config = Config(session);
        config.updateMode = Config.UpdateMode.LATEST_CAMERA_IMAGE;
        var aid = AugmentedImageDatabase(session)

        var image = BitmapFactory.decodeResource(resources, R.drawable.test_ar)
        aid.addImage("image", image)

        config.setAugmentedImageDatabase(aid)
        this.arSceneView.setupSession(session)
        return config
    }

    override fun onCreateView( inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle? ): View? {
        var frameLayout:FrameLayout = super.onCreateView(inflater, container, savedInstanceState) as FrameLayout
        planeDiscoveryController.hide()
        planeDiscoveryController.setInstructionView(null)
        return frameLayout
    }

}