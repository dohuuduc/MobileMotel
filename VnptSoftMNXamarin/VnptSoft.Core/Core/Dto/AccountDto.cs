
using Newtonsoft.Json;

namespace VnptSoftMNCore.Dto {
  public class AccountDto {
    [JsonProperty(PropertyName = "UserKey")]
    public string UserKey { get; set; }

    [JsonProperty(PropertyName = "AdId")]
    public string AdId { get; set; }

    [JsonProperty(PropertyName = "UpsMail")]
    public string UpsMail { get; set; }

    [JsonProperty(PropertyName = "PassCode")]
    public string PassCode { get; set; }

    [JsonProperty(PropertyName = "GdId")]
    public string GdId { get; set; }

    [JsonProperty(PropertyName = "RanId")]
    public string RanId { get; set; }

    [JsonProperty(PropertyName = "TokenId")]
    public string TokenId { get; set; }

    [JsonProperty(PropertyName = "ContactPointName")]
    public string ContactPointName { get; set; }

    [JsonProperty(PropertyName = "ContactPointPhone")]
    public string ContactPointPhone { get; set; }

    [JsonProperty(PropertyName = "HomeAddress")]
    public string HomeAddress { get; set; }

    [JsonProperty(PropertyName = "WorkAddress")]
    public string WorkAddress { get; set; }

    [JsonProperty(PropertyName = "GeneralInfo")]
    public string GeneralInfo { get; set; }
  }
}
