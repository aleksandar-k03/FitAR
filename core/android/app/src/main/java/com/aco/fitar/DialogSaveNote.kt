package com.aco.fitar

import android.app.Dialog
import android.content.Context
import android.os.Bundle
import android.view.View
import android.view.Window
import android.widget.Button
import com.google.android.material.textfield.TextInputEditText

class DialogSaveNote(context:Context) : Dialog(context) {

    private lateinit var noteText: TextInputEditText
    public lateinit var onCancel:()->Unit;
    public lateinit var onSave:(tx:String)->Unit;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        requestWindowFeature(Window.FEATURE_NO_TITLE)
        setContentView(R.layout.dialog_addnote)

        this.noteText = findViewById(R.id.note_text);

        this.findViewById<Button>(R.id.btn_cancel).setOnClickListener(View.OnClickListener {
            if(::onCancel.isInitialized)
                this.onCancel();
            this.close();
        })

        this.findViewById<Button>(R.id.btn_save).setOnClickListener(View.OnClickListener {
            if(::onSave.isInitialized)
                this.onSave(this.noteText.text.toString());
            this.close();
        })

    }

    private fun close(){
        this.dismiss()
    }


}