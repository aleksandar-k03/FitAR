package com.aco.fitar

import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.opengl.Visibility
import android.os.Bundle
import android.view.View
import android.view.animation.Animation
import android.view.animation.AnimationUtils
import android.widget.Button
import android.widget.ImageView
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityOptionsCompat
import androidx.viewpager.widget.ViewPager
import com.aco.fitar.api.models.LoginResponse
import com.aco.fitar.core.ActivityBase
import com.aco.fitar.core.ModelPreferencesManager
import com.google.android.material.tabs.TabLayout
import com.google.android.material.tabs.TabLayout.OnTabSelectedListener
import kotlin.math.roundToInt

class ActivityTutorial  : ActivityBase() {

    private lateinit var viewPager: ViewPager
    private lateinit var viewPagerAdapter: ActivityTutorialScreenPagerAdapter
    private lateinit var screens:MutableList<ActivityTutorialScreenItem>
    private lateinit var tabLayout:TabLayout
    private lateinit var btnNext:Button
    private lateinit var btnFinish:Button
    private lateinit var loginInformations:LoginResponse

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_tutorial)

        this.loginInformations = ModelPreferencesManager.get<LoginResponse>("login")!!;

        this.screens = mutableListOf()
        screens.add(ActivityTutorialScreenItem("Скенирање просторије", "Након учитавања апликације неопходно је скенирати просторију у којој се налазите. У горњем углу ће бити индикатор процеса скенирања. Након што прикупимо довољно података о просторији бићете у могућности читати и остављати поруке.", R.drawable.icon_tutorial1));
        screens.add(ActivityTutorialScreenItem("Постављање поруке", "Кликон на тачкице скенираног простора ћете добити диалог за унос нове поруке. У простору ће се налазити претходне поруке корисника", R.drawable.icon_tutorial2));
        screens.add(ActivityTutorialScreenItem("Ограничења", "За правилан рад апликације мораћете имати новији телефон због техничких захтјева бољег квалитета камере и процесорске снаге потребне за скенирање просторије.", R.drawable.icon_tutorial3));

        this.viewPager = this.findViewById(R.id.tutorial_viewPage)
        this.viewPagerAdapter = ActivityTutorialScreenPagerAdapter(this, this.screens);
        this.viewPager.adapter = this.viewPagerAdapter

        this.btnNext = findViewById(R.id.template_btnNext)
        btnNext.setOnClickListener({
            if(this.viewPager.currentItem < this.screens.count() -1)
                this.viewPager.setCurrentItem(++this.viewPager.currentItem);
        })

        this.tabLayout = findViewById(R.id.tutorial_tabView)
        this.tabLayout.addOnTabSelectedListener(object : TabLayout.OnTabSelectedListener {
            override fun onTabSelected(tab: TabLayout.Tab) {
                if(viewPager.currentItem == screens.count() - 1)
                    onLastScreen()
            }
            override fun onTabUnselected(tab: TabLayout.Tab) { }
            override fun onTabReselected(tab: TabLayout.Tab) { }
        })

        this.btnFinish = findViewById(R.id.template_btnFinish);

        var isClicked = false;
        this.btnFinish.setOnClickListener({
            if(isClicked)
                return@setOnClickListener

            isClicked = true; // zbog toga sto ucitavanja maina traje duze

            var prefs = this.getSharedPreferences(ModelPreferencesManager.PREFERENCES_NAME, Context.MODE_PRIVATE);
            prefs.edit().putString("tutorial_username", this.loginInformations.username).commit();

            val intent = Intent(this, ActivityMain::class.java)
            startActivity(intent);
            this.finish()

        })

        this.tabLayout = findViewById(R.id.tutorial_tabView)
        this.tabLayout.setupWithViewPager(this.viewPager)


    }

    private var onLastScreenCalled:Boolean = false;
    private fun onLastScreen(){
        if(onLastScreenCalled)
            return;

        onLastScreenCalled =true
        this.viewPager.isEnabled = false
        btnNext.visibility = View.GONE
        tabLayout.visibility = View.GONE
        btnFinish.visibility = View.VISIBLE

        var animation:Animation = AnimationUtils.loadAnimation(this, R.anim.button_animation);
        btnFinish.animation = animation;
    }

}