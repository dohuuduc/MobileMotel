using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VnptSoftMNXamarin.Common.Helpers
{
  public class HttpClientHelper: IHttpClientHelper {
    public async Task<TOutput> GetAsync<TOutput>(HttpClient httpClient, string apiUrl) {
      if(string.IsNullOrEmpty(apiUrl)) {
        throw new ArgumentNullException(nameof(apiUrl));
      }

      var uri = new Uri(string.Format(apiUrl, string.Empty));

      var httpResponseMessage = await httpClient.GetAsync(uri);

      if(!httpResponseMessage.IsSuccessStatusCode) {
        return default(TOutput);
      }

      var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;

      return JsonConvert.DeserializeObject<TOutput>(jsonString);
    }

    public async Task<TOutput> PostAsync<TInput, TOutput>(HttpClient httpClient, string apiUrl, TInput data) {
      if(string.IsNullOrEmpty(apiUrl)) {
        throw new ArgumentNullException(nameof(apiUrl));
      }

      if(data == null) {
        throw new ArgumentNullException(nameof(data));
      }

      var uri = new Uri(string.Format(apiUrl, string.Empty));
      var contentData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

      var httpResponseMessage = await httpClient.PostAsync(uri, contentData);

      if(!httpResponseMessage.IsSuccessStatusCode) {
        return default(TOutput);
      }

      var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;

      return JsonConvert.DeserializeObject<TOutput>(jsonString);
    }

    public async Task<ImageSource> PostStreamAsync(HttpClient httpClient, string apiUrl, string data) {
      if(string.IsNullOrEmpty(apiUrl)) {
        throw new ArgumentNullException(nameof(apiUrl));
      }

      if(data == null) {
        throw new ArgumentNullException(nameof(data));
      }

      var uri = new Uri(string.Format(apiUrl, string.Empty));
      var contentData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

      var httpResponseMessage = await httpClient.PostAsync(uri, contentData);

      if(!httpResponseMessage.IsSuccessStatusCode) {
        return default(ImageSource);
      }

      var responseStream = httpResponseMessage.Content.ReadAsStreamAsync().Result;

      return ImageSource.FromStream(() => responseStream);
    }
  }
}
