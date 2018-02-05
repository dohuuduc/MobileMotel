using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VnptSoftMNXamarin.Common.Constants;
using VnptSoftMNXamarin.Common.Helpers;
using Xamarin.Forms;

namespace VnptSoftMNXamarin.Services
{
  public class AccountService: BaseService, IAccountService {
    private readonly IHttpClientHelper _httpClientHelper;
    private readonly HttpClient _httpClient;

    public AccountService(IHttpClientHelper httpClientHelper, ICredentialHelper credentialHelper) {
      _httpClientHelper = httpClientHelper;
      _httpClient = InitHttpClient(credentialHelper.GetCredential());
    }

    public async Task<AccountInfo> GetAccountInfo() {
      var getAccountInfoApi = $"{AppConstant.BaseUrl}api/account/getAccountInfo";

      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      return await _httpClientHelper.GetAsync<AccountInfo>(_httpClient, getAccountInfoApi);
    }

    public async Task<ImageSource> GetAvatar(string avatarUrl) {
      var getAccountInfoApi = $"{AppConstant.BaseUrl}api/account/getAvatar";

      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/png"));

      return await _httpClientHelper.PostStreamAsync(_httpClient, getAccountInfoApi, avatarUrl);
    }

    Task<ImageSource> IAccountService.GetAvatar(string avatarUrl) {
      throw new NotImplementedException();
    }
  }
}
