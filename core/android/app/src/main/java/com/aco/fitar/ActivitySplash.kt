package com.aco.fitar

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.widget.ImageView
import androidx.core.app.ActivityOptionsCompat
import androidx.core.view.ViewCompat
import com.aco.fitar.api.controllers.LoginController
import com.aco.fitar.api.models.LoginResponse

class ActivitySplash : AppCompatActivity() {

    private lateinit var logoImg:ImageView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_splash)

        logoImg = this.findViewById(R.id.splash_logo) as ImageView;

        var a:LoginController = LoginController()

        var hander = Handler();
        hander.postDelayed(Runnable {

            val intent = Intent(this, ActivityLogin::class.java)
            val options = ActivityOptionsCompat.makeSceneTransitionAnimation(this, this.logoImg,
                "splash_logo"
            )
            startActivity(intent, options.toBundle());

        }, 800);


    }
}
