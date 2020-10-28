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
    class ApiGraphicsFinanDataStore : IDataStore<Graph_Finan>
    {
        private const string API_BASE_URL = "http://54.157.172.217:6042/";
        private const string API_PROTO = "entities/proto/finance";
        
        public ApiGraphicsFinanDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Graph_Finan> AddItemRetAsync(Graph_Finan item)
        {
            Graph_Finan retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_Finan>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Graph_Finan item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Graph_Finan> GetItemAsync(string id)
        {
            Graph_Finan retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_Finan>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Graph_Finan>> GetItemsAsync()
        {
            List<Graph_Finan> lista = new List<Graph_Finan>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_Finan>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }
        
        public async Task<IEnumerable<Graph_Finan>> GetItemsAsync(string id)
        {
            List<Graph_Finan> lista = new List<Graph_Finan>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_Finan>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }


        public async Task<bool> UpdateItemAsync(Graph_Finan item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
