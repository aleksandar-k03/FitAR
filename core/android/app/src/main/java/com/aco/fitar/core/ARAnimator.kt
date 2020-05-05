package com.aco.fitar.core

import android.animation.TimeInterpolator
import android.animation.ValueAnimator
import android.text.BoringLayout
import android.util.Log
import android.view.View
import android.view.animation.AccelerateDecelerateInterpolator
import android.view.animation.Animation

class ARAnimator(duration:Long, onUpdate:(progress:Float) -> Unit){

    public var onUpdate: (progress:Float) -> Unit = onUpdate
    public lateinit var onFinish:() -> Unit?
    public var interpolator:TimeInterpolator = AccelerateDecelerateInterpolator()
    public var goForward:Boolean = true
    public var animationDuration:Long = duration

    public fun reference(){

    }

    public fun start(){
        var animator = this.getValueAnimator(this.goForward, this.animationDuration, interpolator,
        {progress ->
            Log.d("ANIMATOR", "progress" + progress.toString())
            if((this.goForward && progress == 1f) || (!this.goForward && progress == 0f))
                this.finalize();
            else
                this.onUpdate(progress);
        });
        animator.start();
    }

    private fun finalize() {
        if(::onFinish.isInitialized && this.onFinish != null){
            Log.d("ANIMATOR", "calling onFinish")
            this.onFinish();
        }
    }


    fun getValueAnimator(forward: Boolean = true, duration: Long, interpolator: TimeInterpolator,
                         updateListener: (progress: Float) -> Unit
    ): ValueAnimator {
        Log.d("ANIMATOR", "getting valueanimator with forward=${forward.toString()}")
        val a =
            if (forward) ValueAnimator.ofFloat(0f, 1f)
            else ValueAnimator.ofFloat(1f, 0f)
        a.addUpdateListener { updateListener(it.animatedValue as Float) }
        a.duration = duration
        a.interpolator = interpolator
        return a
    }



}