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
    class ApiMonitorDataStore : IDataStore<Sector_status_aux>
    {
        private const string API_BASE_URL = "http://54.157.172.217:6042/";
        private const string API_PROTO = "entities/proto";
        
        public ApiMonitorDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Obj_Sector> AddItemRetAsync(Obj_Sector item)
        {
            Obj_Sector retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Obj_Sector>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Obj_Sector item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}/{item.sector_tag}/poll", item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Obj_Sector> GetItemAsync(string id)
        {
            Obj_Sector retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Obj_Sector>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Obj_Sector>> GetItemsAsync()
        {
            List<Obj_Sector> lista = new List<Obj_Sector>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Obj_Sector>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<IEnumerable<Obj_Sector>> GetItemsAsync(string id)
        {
            List<Obj_Sector> lista = new List<Obj_Sector>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Obj_Sector>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Obj_Sector item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}/{item.sector_tag}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
