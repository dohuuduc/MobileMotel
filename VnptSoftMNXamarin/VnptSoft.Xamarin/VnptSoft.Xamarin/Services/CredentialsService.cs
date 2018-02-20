using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoft.Xamarin.Common.Constants;
using Xamarin.Auth;

namespace VnptSoft.Xamarin.Services
{
  public class CredentialsService: ICredentialsService {
    public string UserName {
      get {
        var account = AccountStore.Create().FindAccountsForService(AppConstant.AppName).FirstOrDefault();
        return (account != null) ? account.Username : null;
      }
    }

    public string Password {
      get {
        var account = AccountStore.Create().FindAccountsForService(AppConstant.AppName).FirstOrDefault();
        return (account != null) ? account.Properties["Password"] : null;
      }
    }

    public void SaveCredentials(string userName, string password) {
      if(!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password)) {
        Account account = new Account {
          Username = userName
        };
        account.Properties.Add("Password", password);
        AccountStore.Create().Save(account, AppConstant.AppName);
      }

    }

    //public void SaveBenhVienId(string benhVienId)
    //{
    //    if (!string.IsNullOrWhiteSpace(benhVienId))
    //    {
    //        Account account = new Account();
    //        account.Properties.Add("BenhVienId", benhVienId);
    //        AccountStore.Create().Save(account, AppConstant.BenhVienId);
    //    }
    //}

    public void DeleteCredentials() {
      var account = AccountStore.Create().FindAccountsForService(AppConstant.AppName).FirstOrDefault();
      if(account != null) {
        AccountStore.Create().Delete(account, AppConstant.AppName);
      }
    }

    public bool DoCredentialsExist() {
      return AccountStore.Create().FindAccountsForService(AppConstant.AppName).Any() ? true : false;
    }
  }
}
