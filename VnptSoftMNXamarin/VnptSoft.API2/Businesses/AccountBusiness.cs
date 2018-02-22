using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoft.API2.Common.Helpers;
using VnptSoft.API2.Repositories;
using VnptSoftMNCore.Core.Constants;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Businesses {
  public class AccountBusiness: IAccountBusiness {
    private readonly IAccountRepository _accountRepository;
    private readonly IJiraIntegrationHelper _jiraIntegrationHelper;

    public AccountBusiness(IAccountRepository accountRepository, IJiraIntegrationHelper jiraIntegrationHelper) {
      _accountRepository = accountRepository;
      _jiraIntegrationHelper = jiraIntegrationHelper;
    }

    public async Task<AccountInfo> GetAccountInfoByUserKey(JiraCredential jiraCredential) {
      if(jiraCredential == null) {
        throw new ArgumentNullException(nameof(jiraCredential));
      }

      // Get user profile from jira
      var userProfileResponse = await _jiraIntegrationHelper.GetAsync(jiraCredential, AppConstant.UserProfileUrl + jiraCredential.UserName);

      if(!userProfileResponse.IsSuccessStatusCode) {
        return null;
      }

      var jsonString = userProfileResponse.Content.ReadAsStringAsync().Result;

      var replaceJsonString = jsonString.Replace("16x16", "_16x16").Replace("24x24", "_24x24").Replace("32x32", "_32x32").Replace("48x48", "_48x48");

      // Parse response json to list of user profile
      var userProfiles = JsonConvert.DeserializeObject<List<UserProfile>>(replaceJsonString);

      // Get first in list of user profile
      var userProfile = userProfiles != null && userProfiles.Count > 0 ? userProfiles.FirstOrDefault() : null;

      if(userProfile == null) {
        return null;
      }

      // Get UPS infomation of user
      var accountDto = await _accountRepository.GetAccountInfoByUserKey(jiraCredential.UserName);

      return new AccountInfo {
        AdId = accountDto.AdId,
        AvatarUrl = userProfile.AvatarUrls._48x48,
        ContactPointName = accountDto.ContactPointName,
        ContactPointPhone = accountDto.ContactPointPhone,
        DisplayName = userProfile.DisplayName,
        GdId = accountDto.GdId,
        GeneralInfo = accountDto.GeneralInfo,
        HomeAddress = accountDto.HomeAddress,
        PassCode = accountDto.PassCode,
        RanId = accountDto.RanId,
        TokenId = accountDto.TokenId,
        UpsMail = accountDto.UpsMail,
        WorkAddress = accountDto.WorkAddress
      };
    }



    public async Task<Stream> GetAvatar(JiraCredential jiraCredential, string avatarUrl) {
      // Get avatar according to user profile
      var avatarResponse = await _jiraIntegrationHelper.GetAsync(jiraCredential, avatarUrl);

      if(!avatarResponse.IsSuccessStatusCode) {
        return null;
      }

      return avatarResponse.Content.ReadAsStreamAsync().Result;
    }
  }
}