using VnptSoft.Xamarin.Common.Helpers;
using VnptSoft.Xamarin.Services;
using VnptSoft.Xamarin.ViewModels;
using Xamarin.Forms.Xaml;

namespace VnptSoft.Xamarin.Views {

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