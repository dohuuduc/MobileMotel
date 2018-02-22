using Microsoft.IdentityModel.Tokens;

namespace VnptSoft.API2.Auth {
  public class TokenAuthOption {
    public static string Audience { get; } = "MyUPSAudience";

    public static string Issuer { get; } = "MyUPSIssuer";

    public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());

    public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
  }
}
