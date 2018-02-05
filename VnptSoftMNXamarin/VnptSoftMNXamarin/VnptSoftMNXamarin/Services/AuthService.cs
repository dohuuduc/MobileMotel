using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNXamarin.Common.Constants;
using VnptSoftMNXamarin.Common.Helpers;
using VnptSoftMNXamarin.Common.Models;

namespace VnptSoftMNXamarin.Services
{
  public class AuthService: BaseService, IAuthService {
    private readonly IHttpClientHelper _httpClientHelper;
    private readonly HttpClient _httpClient;

    public AuthService(IHttpClientHelper httpClientHelper) {
      _httpClientHelper = httpClientHelper;
      _httpClient = InitHttpClient();
    }

    public async Task<AuthData> Login(JiraCredential jiraCredential) {
      //var loginApi = $"{AppConstant.BaseUrl}api/auth/login";
      var loginApi = $"{AppConstant.BaseUrl}api/Login";
      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      return await _httpClientHelper.PostAsync<JiraCredential, AuthData>(_httpClient, loginApi, jiraCredential);



    }
  }
}
