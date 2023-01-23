using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace CarReservation.Services
{
    public class HttpService
    {
        private HttpClient _client;
        private readonly IConfiguration _config;
        private string _baseUrl;

        public HttpService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            _baseUrl = _config.GetValue<string>("baseurl");
        }

        public async Task<HttpResponseMessage> PostMethodHttpClient(object? obj, string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, content);
        }
        public async Task<string> GetMethodHttpClient(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(_baseUrl + url);
            return response.Content.ReadAsStringAsync().Result;
        }
        public async Task<string> PostMethodWithQueryParamter(Dictionary<string,string> parameters,string url)
        {
            WebClient wc = new WebClient();
            foreach (var param in parameters)
            {
                wc.QueryString.Add(param.Key, param.Value);
            }
            var data = wc.UploadValues(_baseUrl+url, "POST", wc.QueryString);
            return  UnicodeEncoding.UTF8.GetString(data);
        }
    }
}
