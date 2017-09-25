package com.ext.vnpt.apptro.view.activity;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.ext.vnpt.apptro.R;
import com.ext.vnpt.apptro.presenter.MyPresenter;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    private EditText editUserName,editPassword;
    private MyPresenter myPresenter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_demo);
        initView();
    }
    private void initView(){
        myPresenter = new MyPresenter();
        myPresenter.setListener(new MyPresenter.OnCallBack(){
            @Override
            public  void disableEditText(){
                editPassword.setEnabled(false);
                editUserName.setEnabled(false);
            }
        });

        editUserName =(EditText) findViewById(R.id.edit_user);
        editPassword =(EditText)findViewById(R.id.edit_pasword);
        findViewById(R.id.btn_login).setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.btn_login:
                myPresenter.login(editUserName.getText().toString(),editPassword.getText().toString());
                break;
        }
    }
}
