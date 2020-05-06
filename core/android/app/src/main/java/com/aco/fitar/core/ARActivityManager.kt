package com.aco.fitar.core

import android.app.Activity
import android.app.ActivityManager
import android.content.Context
import android.os.Build
import android.os.Build.VERSION_CODES
import android.widget.Toast
import com.aco.fitar.ActivityMain
import com.aco.fitar.ActivityPlayground
import com.aco.fitar.R
import com.google.ar.core.Anchor
import com.google.ar.sceneform.AnchorNode
import com.google.ar.sceneform.rendering.ModelRenderable
import com.google.ar.sceneform.rendering.Renderable
import com.google.ar.sceneform.ux.ArFragment
import com.google.ar.sceneform.ux.TransformableNode


class ARActivityManager(arFragment: ArFragment?) {

    private var arFragment:ArFragment? = arFragment

    init {

    }

    public fun initiateOnTap(){
        this.arFragment?.setOnTapArPlaneListener({ hitResult, plane, motionEvent ->
            val anchor = hitResult.createAnchor();
            placeObject(anchor)
        });
    }

    private fun placeObject(anchor: Anchor) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            ModelRenderable.builder()
                .setSource(arFragment?.context, R.raw.yen)
                .build()
                .thenAccept({ modelRenderable -> arFragment?.let { addNodeToScene(it, anchor, modelRenderable) } })
                .exceptionally { throwable ->
                    Toast.makeText(arFragment?.context, "Error:" + throwable.message, Toast.LENGTH_LONG)
                        .show()
                    null
                }
        }
    }

    private fun addNodeToScene(arFragment: ArFragment, anchor: Anchor, renderable: Renderable) {
        val anchorNode = AnchorNode(anchor)
        val node = TransformableNode(arFragment.transformationSystem)
        node.renderable = renderable
        node.setParent(anchorNode)
        arFragment.arSceneView.scene.addChild(anchorNode)
        node.select()
    }

    public fun checkIsSupportedDeviceOrFinish(activity: Activity): Boolean {
        val MIN_OPENGL_VERSION = 3.0;
        if (Build.VERSION.SDK_INT < VERSION_CODES.N) {
            Toast.makeText(activity, "Sceneform requires Android N or later", Toast.LENGTH_LONG)
                .show()
            return false
        }
        val openGlVersionString =
            (activity.getSystemService(Context.ACTIVITY_SERVICE) as ActivityManager)
                .deviceConfigurationInfo
                .glEsVersion
        if (openGlVersionString.toDouble() < MIN_OPENGL_VERSION) {
            Toast.makeText(activity, "Sceneform requires OpenGL ES 3.0 or later", Toast.LENGTH_LONG).show()
            return false
        }
        return true
    }



}