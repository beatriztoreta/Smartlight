using System.Collections.Generic;
using SmartLight.Helpers;
using SmartLight.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartLight.Services
{
    class ApiGraphicsDataStore : IDataStore<Graph_aux>
    {
        private const string API_BASE_URL = "http://18.207.140.250:6042/";
        private const string API_PROTO = "entities/proto/time_data/week";
        
        public ApiGraphicsDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Graph_aux> AddItemRetAsync(Graph_aux item)
        {
            Graph_aux retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_aux>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Graph_aux item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Graph_aux> GetItemAsync(string id)
        {
            Graph_aux retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_aux>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Graph_aux>> GetItemsAsync()
        {
            List<Graph_aux> lista = new List<Graph_aux>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_aux>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }
        
        public async Task<IEnumerable<Graph_aux>> GetItemsAsync(string id)
        {
            List<Graph_aux> lista = new List<Graph_aux>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_aux>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }


        public async Task<bool> UpdateItemAsync(Graph_aux item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
