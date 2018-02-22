using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNCore.Core.Constants;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Common.Helpers {
  public class JiraIntegrationHelper: IJiraIntegrationHelper {
    public async Task<HttpResponseMessage> GetAsync(JiraCredential jiraCredential, string apiUrl) {
      if(jiraCredential == null) {
        throw new ArgumentNullException(nameof(jiraCredential));
      }

      if(apiUrl == null) {
        throw new ArgumentNullException(nameof(apiUrl));
      }

      var authData = $"{jiraCredential.UserName}:{jiraCredential.Password}";
      var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

      // HttpClient implement IDisposable interface therefor we need to use using block to release memory after usage
      using(var httpClient = new HttpClient()) {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.Timeout = TimeSpan.FromSeconds(AppConstant.HttpClientTimeOut);

        return await httpClient.GetAsync(apiUrl);
      }
    }
  }
}
