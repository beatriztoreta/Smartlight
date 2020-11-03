using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartLight.Helpers
{
    public static class MobileHelper
    {
        //Definição da conexão e o nome do banco de dados
        private static HttpClient _httpClient;
        private static string _apiUrl;
        
        private static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> CallApi(HttpMethod method, string api, object objectToSend = null)
        {
            var client = GetHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(method, _apiUrl + api))
            {
                if (objectToSend != null)
                {
                    string contentToSend = JsonConvert.SerializeObject(objectToSend);
                    request.Content = new StringContent(contentToSend, Encoding.UTF8, "application/json");
                }
                return await client.SendAsync(request);
            }
        }

        internal static void SetApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
        }
    }
}
