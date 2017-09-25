package com.ext.vnpt.apptro.presenter;

import com.ext.vnpt.apptro.manager.UserManager;

/**
 * Created by Admin on 23/09/2017.
 */

public class MyPresenter {
    private OnCallBack listener;
    public MyPresenter() {
        UserManager.getInstance().addUser("hungp3","123456");
    }
    /*
    public boolean login(String userName,String password){
        return UserManager.getInstance().validInformation(userName,password);
    }
    */

    public  void setListener(OnCallBack listener){
        this.listener=listener;
    }
    public void login(String userName,String pass){
        if(UserManager.getInstance().validInformation(userName,pass)){
            listener.disableEditText();
        }
    }

    public  interface OnCallBack{
        void disableEditText();
    }
}
