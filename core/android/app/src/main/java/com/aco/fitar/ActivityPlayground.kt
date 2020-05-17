package com.aco.fitar

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.aco.fitar.core.ARActivityManager
import com.aco.fitar.core.ActivityBase
import com.google.ar.sceneform.ux.ArFragment

class ActivityPlayground : ActivityBase(){

    protected lateinit var arManager: ARActivityManager;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        this.setContentView(R.layout.activity_playground);

        val arFragment = supportFragmentManager.findFragmentById(R.id.ux_fragment) as ArFragment;
        this.arManager = ARActivityManager(arFragment);

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