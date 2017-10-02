package com.ext.vnpt.myapplication.presenter;

import com.ext.vnpt.myapplication.prefs.SharedManager;

/**
 * Created by Admin on 29/09/2017.
 */

public class SharedPresenter {
    private OnCallBack listener;
    SharedManager dataManager;
    public SharedPresenter(SharedManager dataManager) {
        this.dataManager=dataManager;
    }

    public  void decideNextActivity(){
        if(dataManager.getPassword()==null){
            listener.openMainActivity();
        }
    }

    public  void setListener(OnCallBack listener){
        this.listener=listener;
    }
    public  interface OnCallBack{
        void openMainActivity();
        void openLoginActivity();
    }
}
