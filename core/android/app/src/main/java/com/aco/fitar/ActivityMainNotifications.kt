package com.aco.fitar

import android.os.Handler
import android.widget.LinearLayout
import android.widget.TextView


enum class NotificationType{
    green, red, yellow
}

enum class NotificationDuration{
    short, medium, long
}

class ActivityMainNotifications(var context:ActivityMain) {

    private lateinit var holder:LinearLayout

    public fun init(){
        this.holder = context.findViewById(R.id.notification_holder)
    }

    public fun addNotification(text:String, type:NotificationType = NotificationType.green, durationType: NotificationDuration = NotificationDuration.medium){
        context.runOnUiThread({
            var notification: LinearLayout = context.layoutInflater.inflate(R.layout.notification, null) as LinearLayout
            notification.findViewById<TextView>(R.id.notification_text).text = text;
            notification.alpha = 0f;

            if(type == NotificationType.green)
                notification.findViewById<LinearLayout>(R.id.notification_holder).setBackgroundResource(R.drawable.activity_notification_green)
            else if(type == NotificationType.red)
                notification.findViewById<LinearLayout>(R.id.notification_holder).setBackgroundResource(R.drawable.activity_notification_red)
            else if(type == NotificationType.yellow)
                notification.findViewById<LinearLayout>(R.id.notification_holder).setBackgroundResource(R.drawable.activity_notification_yellow)

            this.holder.addView(notification);
            notification.animate().alpha(1f).setDuration(300).start();

            var duration:Long = 3000;
            if(durationType == NotificationDuration.medium) duration = 6000;
            else if(durationType == NotificationDuration.long) duration = 10000;

            Handler().postDelayed(Runnable{
                notification.animate().alpha(0f).withEndAction(Runnable {
                    context.runOnUiThread({
                        this.holder.removeView(notification);
                    })
                }).setDuration(300).start();
            }, duration);
        })
    }
}