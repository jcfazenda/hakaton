using System.Net.Http;

namespace Api.Domain.Configure
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public string GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
