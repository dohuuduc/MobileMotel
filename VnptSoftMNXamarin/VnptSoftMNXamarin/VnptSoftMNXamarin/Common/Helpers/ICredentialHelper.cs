﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoftMNXamarin.Common.Helpers {
  public interface ICredentialHelper {
    Task StoreCredential(string userName, string token);

    string GetCredential();

    Task DeleteCredential();
  }
}
