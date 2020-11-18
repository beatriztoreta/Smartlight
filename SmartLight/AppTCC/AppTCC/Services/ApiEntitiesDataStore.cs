﻿using System.Collections.Generic;
using SmartLight.Helpers;
using SmartLight.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartLight.Services
{
    class ApiEntitiesDataStore : IDataStore<Entity>
    {
        private const string API_BASE_URL = "http://18.207.140.250:6042/";
        private const string API_PROTO = "entities";
        
        public ApiEntitiesDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<Entity> AddItemRetAsync(Entity item)
        {
            Entity retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Entity>(content);
            }
            return retorno;
        }

        public async Task<bool> AddItemAsync(Entity item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PROTO, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PROTO}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Entity> GetItemAsync(string id)
        {
            Entity retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PROTO}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Entity>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Entity>> GetItemsAsync()
        {
            List<Entity> lista = new List<Entity>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Entity>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<IEnumerable<Entity>> GetItemsAsync(string id)
        {
            List<Entity> lista = new List<Entity>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PROTO);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Entity>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Entity item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PROTO}/{item._id}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
