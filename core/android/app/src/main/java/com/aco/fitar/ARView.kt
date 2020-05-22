package com.aco.fitar

import android.view.View
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import com.google.ar.core.Anchor
import com.google.ar.sceneform.AnchorNode
import com.google.ar.sceneform.rendering.ViewRenderable
import com.google.ar.sceneform.ux.ArFragment
import com.microsoft.azure.spatialanchors.CloudSpatialAnchor
import org.w3c.dom.Text

class ARView  {

    public var defaultText:String ="[]";
    public var defaultUsername:String=""

    public lateinit var anchor:Anchor
    public lateinit var anchorNode: AnchorNode
    public lateinit var cloudAnchor: CloudSpatialAnchor
    public var isRendered:Boolean = false

    private lateinit var arFragment: ArFragment
    private lateinit var usernameInfo:String;

    private lateinit var profileImg:ImageView
    public lateinit var username:TextView
    public lateinit var noteText:TextView
    public lateinit var statusImg:ImageView
    public lateinit var statusText:TextView
    public var hideAdditionalInformations:Boolean = false
    public lateinit var additionalInformationHolder:LinearLayout

    constructor(arFragment: ArFragment, cloudAnchor:CloudSpatialAnchor) {
        this.construct(arFragment, cloudAnchor);
    }


    private fun construct(arFragment: ArFragment, cloudAnchor:CloudSpatialAnchor){
        this.arFragment = arFragment

        this.anchor = cloudAnchor.localAnchor;
        this.anchorNode = AnchorNode()
        this.anchorNode.anchor = this.anchor
        this.cloudAnchor = cloudAnchor
    }

    public fun render(){
        ViewRenderable.builder().setView(arFragment.context, R.layout.arimage).build().thenAccept {
            this.isRendered = true;
            this.profileImg = it.view.findViewById(R.id.imageProfile)
            this.username = it.view.findViewById(R.id.username)
            this.noteText = it.view.findViewById(R.id.note_text)
            this.statusImg = it.view.findViewById(R.id.status_img)
            this.statusText = it.view.findViewById(R.id.status_text)
            this.additionalInformationHolder = it.view.findViewById(R.id.arimage_additional)

            if(this.hideAdditionalInformations)
                this.additionalInformationHolder.visibility = View.GONE

            if(this.defaultUsername.isEmpty())
                this.defaultUsername = this.usernameInfo;
            this.username.text = this.defaultUsername
            this.noteText.text = this.defaultText

            this.anchorNode.renderable = it;

            this.anchorNode.setParent(this.arFragment.arSceneView.scene)

            arFragment.arSceneView.scene.addChild(this.anchorNode)

        }
    }

    public fun setText(text:String){
        if(!this.isRendered) return;
        this.noteText.text = text;
    }

    public fun setStatus(text:String){
        if(!this.isRendered) return;
        this.statusText.text = text;
    }

    public fun destroy(){
        this.anchorNode.renderable = null;
        this.arFragment.arSceneView.scene.removeChild(this.anchorNode);
    }

}