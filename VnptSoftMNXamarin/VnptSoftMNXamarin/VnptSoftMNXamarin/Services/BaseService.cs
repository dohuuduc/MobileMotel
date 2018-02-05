using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNXamarin.Common.Constants;
using ModernHttpClient;


namespace VnptSoftMNXamarin.Services
{
  public class BaseService {
    public HttpClient InitHttpClient(string token = null) {
      var httpClient = new HttpClient(new NativeMessageHandler()) {
        Timeout = TimeSpan.FromSeconds(AppConstant.HttpClientTimeOut)
      };

      if(token != null) {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }

      return httpClient;
    }
  }
}
