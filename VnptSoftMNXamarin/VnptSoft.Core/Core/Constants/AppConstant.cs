using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoftMNCore.Core.Constants {
  public class AppConstant {
    public const int HttpClientTimeOut = 30;
    public const string LoginUrl = "https://insight.fsoft.com.vn/jira/rest/auth/1/session";
    public const string UserProfileUrl = "https://insight.fsoft.com.vn/jira/rest/api/2/user/search?username=";
  }
}
