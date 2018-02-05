using VnptSoftMNXamarin.Common.Helpers;
using VnptSoftMNXamarin.Services;
using VnptSoftMNXamarin.ViewModels;
using Xamarin.Forms.Xaml;

namespace VnptSoftMNXamarin.Views {

  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AccountPage {
    public AccountVM vm {
      get => BindingContext as AccountVM;
      set => BindingContext = value;
    }

    public AccountPage() {
      vm = new AccountVM(new AccountService(new HttpClientHelper(), new CredentialHelper()));
      InitializeComponent();
    }

    protected override async void OnAppearing() {
      await vm.InitScreen();
      base.OnAppearing();
    }

    protected override bool OnBackButtonPressed() {
      return true;
    }
  }
}