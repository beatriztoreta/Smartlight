using System;
using System.Collections.Generic;
using System.Text;
using AppTCC.Helpers;
using AppTCC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    class ApiGraphicsDataStore : IDataStore<Graphics_Data>
    {
        private const string API_BASE_URL = "http://54.157.172.217:6042/";
        private const string API_PROTO = "entities";
        
        public ApiGraphicsDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Graphics_Data> AddItemRetAsync(Graphics_Data item)
        {
            Graphics_Data retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graphics_Data>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Graphics_Data item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Graphics_Data> GetItemAsync(string id)
        {
            Graphics_Data retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graphics_Data>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Graphics_Data>> GetItemsAsync()
        {
            List<Graphics_Data> lista = new List<Graphics_Data>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graphics_Data>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Graphics_Data item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
