using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VnptSoft.API2.Businesses;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Controllers {
  [Produces("application/json")]
  [Route("api/Auth")]
  public class AuthController: BaseController {
    private readonly IUserBusiness _userBusiness;
    private readonly ApplicationConfig _options;
    public AuthController(IUserBusiness userBusiness, IOptions<ApplicationConfig> options) {
      _userBusiness = userBusiness;
      _options = options.Value;
    }

    // POST api/Auth/login
    [HttpPost]
    [Route("login")]
    public async Task<AuthData> Login([FromBody]JiraCredential jiraCredential) {
      var httpResponseMessage = await _userBusiness.Login(jiraCredential);

      if(!httpResponseMessage.IsSuccessStatusCode) {
        return null;
      }

      var requestAt = DateTime.UtcNow;
      var expiresIn = requestAt + TimeSpan.FromMinutes(_options.AuthenticationExpiryTimeInMinutes);

      return new AuthData {
        ExpiresIn = expiresIn,
        Token = GenerateToken(jiraCredential, expiresIn)
      };
    }
  }
}