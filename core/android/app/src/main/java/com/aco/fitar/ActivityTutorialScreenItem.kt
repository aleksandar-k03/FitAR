package com.aco.fitar

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.viewpager.widget.PagerAdapter
import com.squareup.picasso.Picasso

class ActivityTutorialScreenItem(var title:String, var description:String, var imageUrl:Int) {
}

class ActivityTutorialScreenPagerAdapter(var context:ActivityTutorial, var screens:MutableList<ActivityTutorialScreenItem>) : PagerAdapter(){


    override fun isViewFromObject(view: View, `object`: Any): Boolean {
        return view == `object`;
    }

    override fun getCount(): Int {
        return this.screens.count()
    }

    override fun instantiateItem(container: ViewGroup, position: Int): Any {
        var layoutInflater:LayoutInflater = context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        var view = layoutInflater.inflate(R.layout.activity_tutorial_screen, null) as View

        var screen:ActivityTutorialScreenItem = this.screens.get(position)
        //Picasso.get().load(screen.imageUrl).into(view.findViewById<ImageView>(R.id.activity_tutorial_image));
        view.findViewById<ImageView>(R.id.activity_tutorial_image).setImageResource(screen.imageUrl)
        view.findViewById<TextView>(R.id.activity_tutorial_title).text = screen.title;
        view.findViewById<TextView>(R.id.activity_tutorial_description).text = screen.description

        container.addView(view);
        return view;
    }

    override fun destroyItem(container: ViewGroup, position: Int, `object`: Any) {
        container.removeView(`object` as View)
    }

}