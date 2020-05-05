package com.aco.fitar

import android.content.Intent
import android.net.Uri
import android.os.Build
import android.os.Bundle
import android.view.MotionEvent
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.aco.fitar.core.ARActivityManager
import com.aco.fitar.core.ActivityBase
import com.google.ar.core.Anchor
import com.google.ar.core.HitResult
import com.google.ar.core.Plane
import com.google.ar.sceneform.AnchorNode
import com.google.ar.sceneform.rendering.ModelRenderable
import com.google.ar.sceneform.rendering.Renderable
import com.google.ar.sceneform.ux.ArFragment
import com.google.ar.sceneform.ux.TransformableNode


class ActivityMain : ActivityBase(){

    protected lateinit var arManager: ARActivityManager;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        this.setContentView(R.layout.activity_main);

        val arFragment = supportFragmentManager.findFragmentById(R.id.ux_fragment) as ArFragment;
        this.arManager = ARActivityManager(this, arFragment);

        // provjera da li uredjaj moze da prikaze AR
        if(arManager.checkIsSupportedDeviceOrFinish(this) ==  false){
            //  izbaci AR fragment jer nam ocigledno ne treba
            supportFragmentManager.beginTransaction().remove(arFragment).commit()

            /*val intent = Intent(this, ActivityPlayground::class.java)
            startActivity(intent);
            this.finish();*/
        }
        else{
            this.arManager.initiateOnTap();
        }

    }

}