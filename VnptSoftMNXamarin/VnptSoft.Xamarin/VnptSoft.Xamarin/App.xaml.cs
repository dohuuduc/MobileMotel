using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using VnptSoft.Xamarin.Common.Helpers;
using VnptSoft.Xamarin.Views;
using Xamarin.Forms;

namespace VnptSoft.Xamarin {
  public partial class App {

    private readonly ICredentialHelper _credentialHelper = new CredentialHelper();
    private const string AppSecretiOs = "4b50fe94-26a3-4cf1-8d89-d8caaa51db49";
    private const string AppSecretAndroid = "3d5d4a2b-123e-4288-ac21-226b9320b19a";
    private const string AppSecretUWP = "6d9e24d2-c513-4f40-928f-95b5efd8059a";

    public App() {
      InitializeComponent();

      //MainPage = new VnptSoft.Xamarin.MainPage();
      MainPage = new LoginPage();
    }

    protected override void OnStart() {
      // Handle when your app starts
      MobileCenter.Start($"ios={AppSecretiOs};uwp={AppSecretUWP};android={AppSecretAndroid}", typeof(Analytics), typeof(Crashes));
    }

    protected override async void OnSleep() {
      // Handle when your app sleeps
      await _credentialHelper.DeleteCredential();
    }

    protected override void OnResume() {
      // Handle when your app resumes
    }
  }
}

