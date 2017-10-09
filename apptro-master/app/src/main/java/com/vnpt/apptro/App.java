package com.vnpt.apptro;

import android.app.Application;
import android.content.Context;

import com.vnpt.apptro.manager.SharedManager;
import com.vnpt.apptro.model.SharedPrefsHelper;

/**
 * Created by pc_luulong on 9/10/2017.
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

