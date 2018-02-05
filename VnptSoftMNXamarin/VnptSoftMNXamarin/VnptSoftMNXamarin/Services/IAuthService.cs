using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNXamarin.Common.Models;

namespace VnptSoftMNXamarin.Services {
  public interface IAuthService {
    Task<AuthData> Login(JiraCredential jiraCredential);
  }
}
