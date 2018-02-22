﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoft.API2.Auth {
  public class RSAKeyHelper {
    public static RSAParameters GenerateKey() {
      using(var key = new RSACryptoServiceProvider(2048)) {
        return key.ExportParameters(true);
      }
    }
  }
}
