package com.aco.fitar

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.view.animation.Animation
import android.view.animation.AnimationUtils
import android.widget.ImageView
import androidx.core.app.ActivityOptionsCompat
import com.aco.fitar.api.ApiManager
import com.aco.fitar.api.controllers.LoginController
import com.aco.fitar.api.models.LoginModel
import com.aco.fitar.api.models.LoginResponse
import com.aco.fitar.core.ActivityBase
import com.aco.fitar.core.ModelPreferencesManager

class ActivitySplash : ActivityBase() {

    private lateinit var logoImg:ImageView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_splash)
        ApiManager.init(this)

        logoImg = this.findViewById(R.id.splash_logo) as ImageView;
        var animation: Animation = AnimationUtils.loadAnimation(this, R.anim.button_animation);
        logoImg.animation = animation;

        var loginInformations = ModelPreferencesManager.get<LoginResponse>("login");

        var a:LoginController = LoginController()

        var hander = Handler();
        hander.postDelayed(Runnable {

            if(loginInformations == null)
                this.gotoLogin();
            else
            {
                var passwordCache:String = loginInformations.password
                LoginController().call(loginInformations.username, loginInformations.password, { loginResponse ->
                    if(loginResponse.hasError)
                    {
                        this.gotoLogin();
                        return@call;
                    }

                    loginResponse.password = passwordCache;
                    ModelPreferencesManager.put(loginResponse, "login");

                    val intent = Intent(this, ActivityMain::class.java)
                    startActivity(intent);
                    this.finish()

                })
            }

        }, 800);
    }

    public fun gotoLogin(){
        val intent = Intent(this, ActivityLogin::class.java)
        val options = ActivityOptionsCompat.makeSceneTransitionAnimation(this, this.logoImg,
            "splash_logo"
        )
        startActivity(intent, options.toBundle());
    }
}
