package com.vnpt.apptro.view.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;

import com.vnpt.apptro.App;
import com.vnpt.apptro.manager.SharedManager;
import com.vnpt.apptro.presenter.SharedPresenter;

/**
 * Created by pc_luulong on 9/10/2017.
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