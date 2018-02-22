using System;
using System.Net.Http;
using System.Threading.Tasks;
using VnptSoft.API2.Common.Helpers;
using VnptSoft.API2.Repositories;
using VnptSoftMNCore.Core.Constants;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Businesses {
  public class UserBusiness: IUserBusiness {
    private readonly IUserRepository _userRepository;
    private readonly IJiraIntegrationHelper _jiraIntegrationHelper;

    public UserBusiness(IUserRepository userRepository, IJiraIntegrationHelper jiraIntegrationHelper) {
      _userRepository = userRepository;
      _jiraIntegrationHelper = jiraIntegrationHelper;
    }

    public async Task<HttpResponseMessage> Login(JiraCredential jiraCredential) {
      if(jiraCredential == null) {
        throw new ArgumentNullException(nameof(jiraCredential));
      }

      var isExist = await _userRepository.IsExistUserKey(jiraCredential.UserName);

      if(!isExist) {
        return null;
      }

      return await _jiraIntegrationHelper.GetAsync(jiraCredential, AppConstant.LoginUrl);
    }
  }
}

