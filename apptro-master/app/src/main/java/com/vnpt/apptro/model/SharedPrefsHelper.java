package com.vnpt.apptro.model;

import android.content.Context;
import android.content.SharedPreferences;
import android.support.annotation.NonNull;

import static android.content.Context.MODE_PRIVATE;

/**
 * Created by pc_luulong on 9/10/2017.
 */

public class SharedPrefsHelper {
    public static final String MY_PREFS = "userinfo";
    public static final @NonNull
    boolean Remembered =false;
    public static final String Username = "";
    public static final String Password = "";
    public static final String Rights = "";


    SharedPreferences mSharedPreferences;

    public SharedPrefsHelper(Context context) {
        mSharedPreferences = context.getSharedPreferences(MY_PREFS, MODE_PRIVATE);
    }

    public void clear() {
        mSharedPreferences.edit().clear().apply();
    }

    public void putUsername(String username) {
        mSharedPreferences.edit().putString(Username, username).apply();
    }

    public String getUsername() {
        return mSharedPreferences.getString(Username, null);
    }

    public void putPassword(String Password) {
        mSharedPreferences.edit().putString(Password, Password).apply();
    }

    public String getPassword() {
        return mSharedPreferences.getString(Password, null);
    }

}
