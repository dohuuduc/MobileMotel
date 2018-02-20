using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VnptSoft.Xamarin.Common.Helpers {
  public interface IPageHelper {
    Task PushAsync(Page page);

    Task<bool> DisplayAlert(string title, string message, string ok);

    Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
  }
}
