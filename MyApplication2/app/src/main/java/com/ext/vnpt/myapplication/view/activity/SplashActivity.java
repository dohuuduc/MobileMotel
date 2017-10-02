package com.ext.vnpt.myapplication.view.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.widget.EditText;

import com.ext.vnpt.myapplication.App;
import com.ext.vnpt.myapplication.R;
import com.ext.vnpt.myapplication.prefs.SharedManager;
import com.ext.vnpt.myapplication.presenter.SharedPresenter;

/**
 * Created by Admin on 29/09/2017.
 */

public class SplashActivity extends AppCompatActivity {
    private SharedPresenter sharedPresenter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        SharedManager dataManager = ((App) getApplication()).getDataManager();
        sharedPresenter = new SharedPresenter(dataManager);
        initView();
        sharedPresenter.decideNextActivity();
    }

    private void initView(){
        sharedPresenter.setListener(new SharedPresenter.OnCallBack(){
            @Override
            public  void openMainActivity(){
                Intent mainIntent = new Intent(SplashActivity.this, MainActivity.class);
                SplashActivity.this.startActivity(mainIntent);
                SplashActivity.this.finish();
            }
            @Override
            public  void openLoginActivity(){

            }
        });
    }

}
