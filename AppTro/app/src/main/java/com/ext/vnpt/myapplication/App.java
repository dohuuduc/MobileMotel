package com.ext.vnpt.myapplication;

import android.app.Application;
import android.content.Context;

import com.ext.vnpt.myapplication.prefs.SharedManager;
import com.ext.vnpt.myapplication.prefs.SharedPrefsHelper;

/**
 * Created by Admin on 29/09/2017.
 */

public class App extends Application {
    SharedManager dataManager;
    private  static App mSelf;
    /** A flag to show how easily you can switch from standard SQLite to the encrypted SQLCipher. */
    public static final boolean ENCRYPTED = true;

   // private DaoSession daoSession;

    public  static  App self(){
        return  mSelf;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        SharedPrefsHelper sharedPrefsHelper = new SharedPrefsHelper(getApplicationContext());
        dataManager = new SharedManager(sharedPrefsHelper);
    }

    public SharedManager getDataManager() {
        return dataManager;
    }

    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(base);
    }
}
