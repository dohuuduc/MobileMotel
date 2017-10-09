package com.vnpt.apptro.presenter;

import com.vnpt.apptro.manager.SharedManager;

/**
 * Created by pc_luulong on 9/10/2017.
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
