package com.aco.fitar

import android.Manifest
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.core.app.ActivityCompat.requestPermissions
import androidx.core.app.ActivityOptionsCompat
import androidx.core.view.GravityCompat
import androidx.drawerlayout.widget.DrawerLayout
import com.aco.fitar.api.MLServer
import com.aco.fitar.api.SendImageCallback
import com.aco.fitar.core.ModelPreferencesManager
import com.squareup.picasso.Picasso

class ActivityMainDrawer(var context:ActivityMain) {

    private lateinit var drawerMain:DrawerLayout
    private lateinit var btn:ImageView
    private lateinit var btnTest:LinearLayout
    private lateinit var btnProfilePic:LinearLayout
    private lateinit var btnLogout:LinearLayout

    private lateinit var imageBack:ImageView
    private lateinit var image:ImageView
    private lateinit var txtUsername:TextView
    private lateinit var txtName:TextView

    public fun init(){
        drawerMain = context.findViewById(R.id.drawer_main)
        btn = context.findViewById(R.id.btnOpenDrawer);
        btnTest = context.findViewById(R.id.drawer_openTest)
        btnProfilePic = context.findViewById(R.id.drawer_changeProfileIcon)
        btnLogout = context.findViewById(R.id.drawer_logout)

        this.imageBack = context.findViewById(R.id.drawer_profilePicBack)
        this.image = context.findViewById(R.id.drawer_profilePic)
        this.txtUsername = context.findViewById(R.id.drawer_username)
        this.txtName = context.findViewById(R.id.drawer_name)

        this.txtUsername.text = context.loginInfo.username;
        this.txtName.text = context.loginInfo.firstName + " " + context.loginInfo.lastName;

        Picasso.get().load(context.loginInfo.profilePic).into(this.image);
        Picasso.get().load(context.loginInfo.profilePic).into(this.imageBack);

        this.btn.setOnClickListener({
            drawerMain.openDrawer(GravityCompat.START)
            /*
            val rnds = (0 until 3).random()
            var type:NotificationType = NotificationType.red;
            var duration:NotificationDuration = NotificationDuration.long;

            if(rnds == 1){
                type = NotificationType.yellow;
                duration = NotificationDuration.medium;
            }
            if(rnds == 2){
                type = NotificationType.green;
                duration = NotificationDuration.short;
            }

            context.notifications.addNotification("Test1", type, duration);
             */
        });
        this.onTestClick()
        this.onLogout()
        this.onChangeProfilePicture()
    }

    private fun onTestClick(){
        this.btnTest.setOnClickListener({

            context.arManager.arSceneView.destroy()
            context.finish()

            val intent = Intent(context, ActivityPlayground::class.java)
            context.startActivity(intent);

        });
    }

    private fun onLogout(){
        this.btnLogout.setOnClickListener({

            ModelPreferencesManager.put(null, "login");
            val intent = Intent(context, ActivityLogin::class.java)
            context.startActivity(intent);
            context.finish()

        })
    }

    private fun onChangeProfilePicture(){
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            if ((context.checkSelfPermission(Manifest.permission.READ_EXTERNAL_STORAGE) == PackageManager.PERMISSION_DENIED)
                && (context.checkSelfPermission(Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_DENIED)
            ) {
                val permission = arrayOf(Manifest.permission.READ_EXTERNAL_STORAGE)
                val permissionCoarse = arrayOf(Manifest.permission.WRITE_EXTERNAL_STORAGE)

                context.requestPermissions(permission, 1) // GIVE AN INTEGER VALUE FOR PERMISSION_CODE_READ LIKE 1001
                context.requestPermissions(permissionCoarse, 1) // GIVE AN INTEGER VALUE FOR PERMISSION_CODE_WRITE LIKE 1002
            }
        }

        this.btnProfilePic.setOnClickListener({
            val intent = Intent(Intent.ACTION_PICK)
            intent.type = "image/*"
            context.startActivityForResult(intent, 25)
        });
    }

    public fun onImage(img:String){
        context.runOnUiThread({

            Picasso.get().load(img).into(this.image);
            Picasso.get().load(img).into(this.imageBack);
            MLServer.SendImage(SendImageCallback(context.loginInfo.username, img))

        })
    }
}