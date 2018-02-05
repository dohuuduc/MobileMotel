using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoftMNXamarin.Common.Models {
  public class JiraCredential {
    public string UserName { get; set; }
    public string Password { get; set; }

    public JiraCredential(string userName, string password) {
      UserName = userName;
      Password = password;
    }
  }
}
