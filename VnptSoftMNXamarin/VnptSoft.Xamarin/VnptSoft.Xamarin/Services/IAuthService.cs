using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoft.Xamarin.Common.Models;

namespace VnptSoft.Xamarin.Services {
  public interface IAuthService {
    Task<AuthData> Login(JiraCredential jiraCredential);
  }
}
