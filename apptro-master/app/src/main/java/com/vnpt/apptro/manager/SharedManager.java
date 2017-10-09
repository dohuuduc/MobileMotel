package com.vnpt.apptro.manager;

import com.vnpt.apptro.model.SharedPrefsHelper;

/**
 * Created by pc_luulong on 9/10/2017.
 */

public class SharedManager {
    private static SharedManager instance;
    private static SharedPrefsHelper sharedPrefsHelper;
    private  SharedManager(){}
    public  static  SharedManager getInstance(){
        if(instance == null){
            instance= new SharedManager();
        }
        return  instance;
    }

    public SharedManager(SharedPrefsHelper sharedPrefsHelper) {
        this.sharedPrefsHelper = sharedPrefsHelper;
    }

    public void clear() {
        instance.clear();
    }

    public void saveUserInfo(String username,String password,boolean Remembered,String rights) {
        sharedPrefsHelper.putPassword(password);
        sharedPrefsHelper.putUsername(username);
    }

    public String getUsername() {
        return sharedPrefsHelper.getUsername();
    }

    public String getPassword() {
        return sharedPrefsHelper.getPassword();
    }
}
