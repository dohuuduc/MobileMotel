using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoftMNCore.Core.Models {
  public class AuthData {
    public string Token { get; set; }

    public DateTime ExpiresIn { get; set; }
  }
}
