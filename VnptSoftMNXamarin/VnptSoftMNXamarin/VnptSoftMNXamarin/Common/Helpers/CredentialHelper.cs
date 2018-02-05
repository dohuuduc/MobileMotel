using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNXamarin.Common.Constants;
using Xamarin.Auth;

namespace VnptSoftMNXamarin.Common.Helpers {
  public class CredentialHelper: ICredentialHelper {
    public async Task StoreCredential(string userName, string token) {
      var account = new Account(userName);
      account.Properties.Add("Token", token);

      await AccountStore
          .Create()
          .SaveAsync(account, AppConstant.AppKey);
    }

    public string GetCredential() {
      var account = AccountStore
          .Create()
          .FindAccountsForService(AppConstant.AppKey)
          .FirstOrDefault();

      return account?.Properties["Token"];
    }

    public async Task DeleteCredential() {
      var account = AccountStore
          .Create()
          .FindAccountsForService(AppConstant.AppKey)
          .FirstOrDefault();


      await AccountStore
          .Create()
          .DeleteAsync(account, AppConstant.AppKey);
    }
  }
}
