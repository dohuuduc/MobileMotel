using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VnptSoftMNXamarin.Common.Helpers {
  public class PageHelper: IPageHelper {
    public async Task PushAsync(Page page) {
      await Application.Current.MainPage.Navigation.PushModalAsync(page);
    }

    public async Task<bool> DisplayAlert(string title, string message, string ok) {
      return await DisplayAlert(title, message, ok, string.Empty);
    }

    public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel) {
      if(string.IsNullOrEmpty(cancel)) {
        await Application.Current.MainPage.DisplayAlert(title, message, ok);
        return true;
      }

      return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
    }
  }
}
