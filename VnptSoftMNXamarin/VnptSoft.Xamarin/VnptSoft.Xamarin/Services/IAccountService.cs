using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VnptSoft.Xamarin.Services
{
  public interface IAccountService {
    Task<AccountInfo> GetAccountInfo();
    Task<ImageSource> GetAvatar(string avatarUrl);
  }
}

