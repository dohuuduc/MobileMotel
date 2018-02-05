using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VnptSoftMNXamarin.Common.Helpers
{
  public interface IHttpClientHelper {
    Task<TOutput> GetAsync<TOutput>(HttpClient httpClient, string apiUrl);

    Task<TOutput> PostAsync<TInput, TOutput>(HttpClient httpClient, string apiUrl, TInput data);

    Task<ImageSource> PostStreamAsync(HttpClient httpClient, string apiUrl, string data);
  }
}
