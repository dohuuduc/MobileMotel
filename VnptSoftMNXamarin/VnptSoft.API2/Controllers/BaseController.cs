using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VnptSoft.API2.Auth;
using VnptSoftMNCore.Core.Constants;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Controllers {
  public class BaseController: Controller {
    protected JiraCredential GetUserCredential() {
      var claimsIdentity = HttpContext.User.Identities.FirstOrDefault();

      if(claimsIdentity == null) {
        return new JiraCredential(string.Empty, string.Empty);
      }

      var userKey = claimsIdentity
          .Claims
          .AsEnumerable()
          .FirstOrDefault(claim => claim.Type.Equals(MyUpsClaimType.UserKey));

      var password = claimsIdentity
          .Claims
          .AsEnumerable()
          .FirstOrDefault(claim => claim.Type.Equals(MyUpsClaimType.Password));

      return new JiraCredential(userKey != null ? userKey.Value : string.Empty, password != null ? password.Value : string.Empty);
    }

    protected string GenerateToken(JiraCredential jiraCredential, DateTime expires) {
      var handler = new JwtSecurityTokenHandler();

      ClaimsIdentity identity = new ClaimsIdentity(
          new GenericIdentity(jiraCredential.UserName, "TokenAuth"),
          new[] {
                    new Claim(MyUpsClaimType.UserKey, jiraCredential.UserName),
                    new Claim(MyUpsClaimType.Password, jiraCredential.Password)
          }
      );

      var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
        Issuer = TokenAuthOption.Issuer,
        Audience = TokenAuthOption.Audience,
        SigningCredentials = TokenAuthOption.SigningCredentials,
        Subject = identity,
        Expires = expires
      });

      return handler.WriteToken(securityToken);
    }
  }
}
