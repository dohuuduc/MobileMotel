using Newtonsoft.Json;

namespace VnptSoftMNCore.Dto {
  public class UserDto {
    [JsonProperty(PropertyName = "Id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName = "UserKey")]
    public string UserKey { get; set; }
  }
}

