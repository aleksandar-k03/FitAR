package com.aco.fitar.views

import android.content.Context
import android.util.AttributeSet
import android.view.View
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import com.aco.fitar.core.ARAnimator
import com.aco.fitar.setCornerRadius

class LoginInfo : ConstraintLayout{

    constructor(context: Context) : this(context, null)
    constructor(context: Context, attrs: AttributeSet?) : this(context, attrs, 0)
    constructor(context: Context, attrs: AttributeSet?, defStyleAttr: Int) : super(context, attrs, defStyleAttr) {}

    var isInfoVisible:Boolean = false
    lateinit var infoText: TextView

    public fun init(){
        this.visibility = View.VISIBLE
        this.alpha = 0f
        this.setCornerRadius(10)

        this.setOnClickListener({
            this.animateInfoBox(if(this.isInfoVisible) false else true)
        });
    }

    public fun setText(input:String){
        this.displayInfo();
        this.infoText.text = input
    }


    private fun displayInfo(){
        if(this.isInfoVisible)
            return;


        this.animateInfoBox(true)
    }

    private fun animateInfoBox(forward:Boolean){
        val finalWidth = 400

        var animator = ARAnimator(900, { progress ->
            this.infoText.alpha = progress;
            this.alpha = progress
            this.isInfoVisible = forward
        });

        animator.goForward = forward
        animator.start()
    }


}