using System;
using System.Collections.Generic;
using System.Text;
using SmartLight.Helpers;
using SmartLight.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartLight.Services
{
    class ApiGraphicsEficienDataStore : IDataStore<Graph_Entity>
    {
        private const string API_BASE_URL = "http://54.157.172.217:6042/";
        private const string API_PROTO = "entities/proto/time_data/month";
        
        public ApiGraphicsEficienDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Graph_Entity> AddItemRetAsync(Graph_Entity item)
        {
            Graph_Entity retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_Entity>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Graph_Entity item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Graph_Entity> GetItemAsync(string id)
        {
            Graph_Entity retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Graph_Entity>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Graph_Entity>> GetItemsAsync()
        {
            List<Graph_Entity> lista = new List<Graph_Entity>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_Entity>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }
        
        public async Task<IEnumerable<Graph_Entity>> GetItemsAsync(string id)
        {
            List<Graph_Entity> lista = new List<Graph_Entity>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Graph_Entity>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }


        public async Task<bool> UpdateItemAsync(Graph_Entity item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
