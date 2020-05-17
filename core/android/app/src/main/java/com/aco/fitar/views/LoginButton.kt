package com.aco.fitar.views

import android.content.Context
import android.util.AttributeSet
import android.util.Log
import android.view.View
import android.view.ViewGroup
import android.view.ViewTreeObserver
import android.widget.ProgressBar
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import com.aco.fitar.core.ARAnimator
import com.aco.fitar.dp
import com.aco.fitar.setCornerRadius

class LoginButton : ConstraintLayout {

    constructor(context: Context) : this(context, null)
    constructor(context: Context, attrs: AttributeSet?) : this(context, attrs, 0)
    constructor(context: Context, attrs: AttributeSet?, defStyleAttr: Int) : super(context, attrs, defStyleAttr) {}

    var originalWidth:Int  = 0
    lateinit var onClickFun:()->Unit
    lateinit var btnText: TextView
    lateinit var btnProgress: ProgressBar
    private var isOpened = false;
    public var isLoading:Boolean = false

    public fun init(){
        this.originalWidth = this.layoutParams.width
        //this.setCornerRadius(10)

        if(::btnProgress.isInitialized)
            this.btnProgress.alpha = 0f

        this.setOnClickListener({
            if(isLoading)
                return@setOnClickListener
            if(isOpened)
                return@setOnClickListener;

            isLoading = true;
            this.animation(false, {
                this.isOpened = true;
                if(::onClickFun.isInitialized)
                    this.onClickFun();
            });
        });
    }

    public fun finish(){
        this.isOpened = false;
        this.animation(true, null);
    }

    private fun animation(forward:Boolean, onFinish: (() -> Unit)?){
        var animator = ARAnimator(900, onUpdate={progress ->
            var newWidth = (this.originalWidth * progress).toInt() + 80.dp;
            if(newWidth > this.originalWidth) newWidth = this.originalWidth;

            Log.d("LOGIN", "currentWidth:${this.originalWidth} and progres=${progress.toString()}, newWidth:${newWidth}")
            this.layoutParams.width = newWidth
            this.requestLayout()

            this.btnText.alpha = progress
            this.btnProgress.alpha = 1-progress;
        });

        animator.goForward = forward

        if(onFinish != null)
            animator.onFinish = onFinish;

        animator.start()
    }





}