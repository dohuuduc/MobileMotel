package com.ext.vnpt.apptro.manager;

import com.ext.vnpt.apptro.model.User;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Admin on 23/09/2017.
 */

public class UserManager {
    private static UserManager instance;
    List<User> listUser;

    private UserManager(){

    }

    public  static  UserManager getInstance(){
        if(instance ==null)
            instance= new UserManager();
        return  instance;
    }
    public  void addUser(String userName,String passWord){
        if(listUser==null){
            listUser=new ArrayList<>();
        }
        listUser.add(new User(userName,passWord));
    }

    public boolean validInformation(String userName,String password){
        for (int i=0;i<listUser.size();i++){
            if(listUser.get(i).getUserName().equals(userName) && listUser.get(i).getPassWord().equals(password)){
                return true;
            }
        }
        return false;
    }
}
