using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoft.Xamarin.Services;
using Xamarin.Forms;

namespace VnptSoft.Xamarin.ViewModels
{
  public class AccountVM: BaseViewModel {
    private readonly IAccountService _accountService;

    private bool _isLoading;
    public bool IsLoading {
      get => _isLoading;
      set => SetValue(ref _isLoading, value);
    }

    private string _adId;
    public string AdId {
      get => _adId;
      set => SetValue(ref _adId, value);
    }

    private string _upsMail;
    public string UpsMail {
      get => _upsMail;
      set => SetValue(ref _upsMail, value);
    }

    private string _passCode;
    public string PassCode {
      get => _passCode;
      set => SetValue(ref _passCode, value);
    }

    private string _gdId;
    public string GdId {
      get => _gdId;
      set => SetValue(ref _gdId, value);
    }

    private string _ranId;
    public string RanId {
      get => _ranId;
      set => SetValue(ref _ranId, value);
    }

    private string _tokenId;
    public string TokenId {
      get => _tokenId;
      set => SetValue(ref _tokenId, value);
    }

    private string _contactPointName;
    public string ContactPointName {
      get => _contactPointName;
      set => SetValue(ref _contactPointName, value);
    }

    private string _contactPointPhone;
    public string ContactPointPhone {
      get => _contactPointPhone;
      set => SetValue(ref _contactPointPhone, value);
    }

    private string _homeAddress;
    public string HomeAddress {
      get => _homeAddress;
      set => SetValue(ref _homeAddress, value);
    }

    private string _workAddress;
    public string WorkAddress {
      get => _workAddress;
      set => SetValue(ref _workAddress, value);
    }

    private string _generalInfo;
    public string GeneralInfo {
      get => _generalInfo;
      set => SetValue(ref _generalInfo, value);
    }

    private ImageSource _avartarImage;
    public ImageSource AvartarImage {
      get => _avartarImage;
      set => SetValue(ref _avartarImage, value);
    }

    private string _displayName;
    public string DisplayName {
      get => _displayName;
      set => SetValue(ref _displayName, value);
    }

    public AccountVM(IAccountService accountService) {
      _accountService = accountService;
    }

    public async Task InitScreen() {
      IsLoading = true;

      var accountInfo = await _accountService.GetAccountInfo();

      AvartarImage = await _accountService.GetAvatar(accountInfo.AvatarUrl);

      DisplayName = accountInfo.DisplayName;
      AdId = accountInfo.AdId;
      UpsMail = accountInfo.UpsMail;
      PassCode = accountInfo.PassCode;
      GdId = accountInfo.GdId;
      RanId = accountInfo.RanId;
      TokenId = accountInfo.TokenId;
      ContactPointName = accountInfo.ContactPointName;
      ContactPointPhone = accountInfo.ContactPointPhone;
      HomeAddress = accountInfo.HomeAddress;
      WorkAddress = accountInfo.WorkAddress;
      GeneralInfo = accountInfo.GeneralInfo;

      IsLoading = false;
    }
  }
}
