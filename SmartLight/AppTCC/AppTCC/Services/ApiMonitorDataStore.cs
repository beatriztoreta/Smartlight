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
    class ApiMonitorDataStore : IDataStore<Sector_status_aux>
    {
        private const string API_BASE_URL = "http://18.207.140.250:6042/";
        private const string API_PROTO = "entities/proto";
        
        public ApiMonitorDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Sector_status_aux> AddItemRetAsync(Sector_status_aux item)
        {
            Sector_status_aux retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Sector_status_aux>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Sector_status_aux item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Sector_status_aux> GetItemAsync(string id)
        {
            Sector_status_aux retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}/status");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Sector_status_aux>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Sector_status_aux>> GetItemsAsync()
        {
            List<Sector_status_aux> lista = new List<Sector_status_aux>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Sector_status_aux>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<IEnumerable<Sector_status_aux>> GetItemsAsync(string id)
        {
            List<Sector_status_aux> lista = new List<Sector_status_aux>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Sector_status_aux>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Sector_status_aux item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
