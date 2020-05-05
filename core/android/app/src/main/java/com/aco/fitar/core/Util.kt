package com.aco.fitar

import android.content.res.Resources
import android.graphics.drawable.ColorDrawable
import android.graphics.drawable.GradientDrawable
import android.os.Build
import android.view.View
import androidx.annotation.RequiresApi


fun Int.toDp():Int = (this / Resources.getSystem().displayMetrics.density).toInt()
fun Int.toPx():Int = (this * Resources.getSystem().displayMetrics.density).toInt()

val Int.dp: Int
    get() = (this * Resources.getSystem().displayMetrics.density + 0.5f).toInt()

val Float.dp: Int
    get() = (this * Resources.getSystem().displayMetrics.density + 0.5f).toInt()


fun View.setCornerRadius(value:Int){
    var draw: ColorDrawable = this.background as ColorDrawable
    var color = Integer.toHexString(draw.color)

    val shape = GradientDrawable()
    shape.cornerRadius = value.toFloat()
    shape.setColor(draw.color)

    this.background = shape
}