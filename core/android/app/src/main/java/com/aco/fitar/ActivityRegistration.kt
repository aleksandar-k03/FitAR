package com.aco.fitar

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import androidx.core.app.ActivityOptionsCompat
import com.aco.fitar.api.ApiManager
import com.aco.fitar.api.controllers.RegistrationController
import com.aco.fitar.core.ActivityBase
import com.aco.fitar.views.LoginButton
import com.aco.fitar.views.LoginInfo
import com.google.android.material.textfield.TextInputEditText

class ActivityRegistration  : ActivityBase() {

    lateinit var inputUsername: TextInputEditText
    lateinit var inputFirstName: TextInputEditText
    lateinit var inputLastName: TextInputEditText
    lateinit var inputPassword: TextInputEditText
    lateinit var box1: LinearLayout

    lateinit var btn: LoginButton;
    lateinit var btnBackToLogin: TextView
    lateinit var infoBox: LoginInfo

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_registration)
        ApiManager.init(this);


        this.inputUsername = this.findViewById(R.id.login_input_username)
        this.inputPassword = this.findViewById(R.id.login_input_password)
        this.inputFirstName = this.findViewById(R.id.login_input_name)
        this.inputLastName = this.findViewById(R.id.login_input_lastName)

        this.btn = this.findViewById(R.id.login_btn)
        this.btn.btnText = this.findViewById(R.id.login_btn_text)
        this.btn.btnProgress = this.findViewById(R.id.login_btn_progress)

        this.infoBox = this.findViewById(R.id.logo_info)
        this.infoBox.infoText = this.findViewById(R.id.logo_info_text)

        this.btnBackToLogin = this.findViewById(R.id.login_btn_gotoRegistration)
        this.btnBackToLogin.setOnClickListener({ this.navigateToLogin(); })

        this.infoBox.init()

        this.btnFunc()
        this.btn.init()
    }


    private fun btnFunc(){
        var activity = this;
        this.btn.onClickFun = onClickFun@{

            if(this.inputFirstName.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Нисте унијели Име!")
                btn.finish()
                return@onClickFun
            }

            if(this.inputLastName.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Нисте унијели Презиме!")
                btn.finish()
                return@onClickFun
            }

            if(this.inputUsername.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Морате унијети корисничко име")
                btn.finish()
                return@onClickFun
            }

            if(this.inputPassword.text.isNullOrEmpty()){
                btn.isLoading = false;
                this.infoBox.setText("Морате унијети шифру!")
                return@onClickFun
            }

            RegistrationController().call(
                this.inputUsername.text.toString(),
                this.inputFirstName.text.toString(), this.inputLastName.text.toString(),
                this.inputPassword.text.toString(),
                { registrationResponseModel ->
                    btn.isLoading = false;
                    if(registrationResponseModel.hasError){
                        this.infoBox.setText(registrationResponseModel.errorMessage);
                        this.btn.finish();
                        return@call;
                    }
                    this.navigateToLogin();
                    this.finish()
                });
        }
    }

    private fun btnRegistrationFunc(){
        var activity = this;
        this.btnBackToLogin.setOnClickListener({
            this.navigateToLogin();
        });
    }

    private fun navigateToLogin(){
        val intent = Intent(this, ActivityLogin::class.java)
        val options = ActivityOptionsCompat.makeSceneTransitionAnimation(this, this.findViewById(R.id.login_logo),
            "splash_logo"
        )
        startActivity(intent, options.toBundle());
        this.finish()
    }
}