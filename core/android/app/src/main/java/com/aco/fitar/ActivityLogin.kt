package com.aco.fitar

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.text.BoringLayout
import android.util.Log
import android.view.animation.AccelerateDecelerateInterpolator
import android.widget.Button
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.Toast
import androidx.core.app.ActivityOptionsCompat
import com.aco.fitar.api.ApiManager
import com.aco.fitar.api.controllers.LoginController
import com.aco.fitar.core.ActivityBase
import com.aco.fitar.core.ModelPreferencesManager
import com.aco.fitar.views.LoginButton
import com.aco.fitar.views.LoginInfo
import com.google.android.material.textfield.TextInputEditText
import kotlinx.android.synthetic.main.arimage.*


class ActivityLogin : ActivityBase() {

    private lateinit var logoImg: ImageView
    lateinit var inputUsername:TextInputEditText
    lateinit var inputPassword:TextInputEditText
    lateinit var box1:LinearLayout

    lateinit var btn:LoginButton;
    lateinit var btnRegistration: Button

    lateinit var infoBox:LoginInfo

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        ApiManager.init(this);

        this.setContentView(R.layout.activity_login);
        logoImg = this.findViewById(R.id.login_logo) as ImageView;

        this.inputUsername = this.findViewById(R.id.login_input_username)
        this.inputPassword = this.findViewById(R.id.login_input_password)

        this.btn = this.findViewById(R.id.login_btn)
        this.btn.btnText = this.findViewById(R.id.login_btn_text)
        this.btn.btnProgress = this.findViewById(R.id.login_btn_progress)

        this.infoBox = this.findViewById(R.id.logo_info)
        this.infoBox.infoText = this.findViewById(R.id.logo_info_text)

        this.btnRegistration = this.findViewById(R.id.login_btn_gotoRegistration)
        this.btnRegistration.setCornerRadius(50)

        Log.d("LOGIN", "unutar login")

        this.box1 = findViewById(R.id.login_mainbox)
        this.box1.scaleX = 1.2f
        this.box1.scaleY = 1.2f
        this.box1.alpha = 0f
        //this.box1.layoutTransition.enableTransitionType(LayoutTransition.CHANGING)


        this.btnFunc()
        this.btnRegistrationFunc()

        this.infoBox.init()
        this.btn.init();


    }

    override fun onStart() {
        Log.d("LOGIN", "onStart")
        this.box1.animate().setStartDelay(50).alpha(1f).scaleX(1f).scaleY(1f).setInterpolator(AccelerateDecelerateInterpolator()).setDuration(600)
        super.onStart()
    }

    private fun stopAnimation(action:()->Unit){
        Log.d("LOGIN", "stopAnimation")
        this.box1.animate().setStartDelay(5).alpha(0f).scaleX(1.2f).scaleY(1.2f).setInterpolator(AccelerateDecelerateInterpolator()).setDuration(600).withEndAction {
            action();
        }
    }


    private fun btnFunc(){
        var activity = this;
        this.btn.onClickFun = onClickFun@{

            if(this.inputUsername.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Морате унијети корисничко име")
                btn.finish()
                //Toast.makeText(activity, "Nema username", Toast.LENGTH_SHORT).show()
                return@onClickFun
            }

            if(this.inputPassword.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Морате унијети шифру")
                btn.finish()
                //Toast.makeText(activity, "Nema password", Toast.LENGTH_SHORT).show()
                return@onClickFun
            }

            LoginController().call(this.inputUsername.text.toString(), this.inputPassword.text.toString(), { loginResponse ->
                btn.isLoading = false;
                if(loginResponse.hasError){
                    infoBox.setText(loginResponse.errorMessage);
                    btn.finish()
                    return@call;
                }
                loginResponse.password = this.inputPassword.text.toString();
                ModelPreferencesManager.put(loginResponse, "login");
                this.navigateToMain()
            });
        }
    }

    private fun navigateToMain(){

        var prefs = this.getSharedPreferences(ModelPreferencesManager.PREFERENCES_NAME, Context.MODE_PRIVATE);
        var tutorialUsername:String = prefs.getString("tutorial_username", "")!!;

        //Toast.makeText(this, "loginFromPrefs=" + tutorialUsername + ", username=" + this.inputUsername.text.toString(), Toast.LENGTH_LONG).show()

        if(tutorialUsername.equals(this.inputUsername.text.toString()) == false){
            val intent = Intent(this, ActivityTutorial::class.java)
            val options = ActivityOptionsCompat.makeSceneTransitionAnimation(this, this.logoImg, "splash_logo" )
            startActivity(intent, options.toBundle());
            return;
        }

        val intent = Intent(this, ActivityMain::class.java)
        startActivity(intent);
        this.finish()
    }

    private fun btnRegistrationFunc(){
        var activity = this;
        this.btnRegistration.setOnClickListener({
            val intent = Intent(this, ActivityRegistration::class.java)
            val options = ActivityOptionsCompat.makeSceneTransitionAnimation(this, this.findViewById(R.id.login_logo),
                "splash_logo"
            )
            this.stopAnimation {
                startActivity(intent, options.toBundle());
            }
        });
    }


    override fun onBackPressed() {
        finish();
        System.exit(0);
    }


}