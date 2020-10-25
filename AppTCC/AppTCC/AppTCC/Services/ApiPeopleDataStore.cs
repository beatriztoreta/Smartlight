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
    class ApiPeopleDataStore : IDataStore<Person>
    {
        private const string API_BASE_URL = "http://54.157.172.217:6042/";
        private const string API_PESSOAS = "users";
        public ApiPeopleDataStore()
        {
            MobileHelper.SetApiUrl(API_BASE_URL);
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Post, API_PESSOAS, item);
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Person> AddItemRetAsync(Person item)
        {
            Person retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Post, API_PESSOAS, item);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Person>(content);
            }
            return retorno;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Delete, $"{API_PESSOAS}/{id}");
            return retorno.IsSuccessStatusCode;
        }

        public async Task<Person> GetItemAsync(string id)
        {
            Person retorno = null;
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, $"{API_PESSOAS}/{id}");
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<Person>(content);
            }
            return retorno;
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            List<Person> lista = new List<Person>();
            var resposta = await MobileHelper.CallApi(HttpMethod.Get, API_PESSOAS);
            if (resposta.IsSuccessStatusCode)
            {
                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<Person>>(content);
                lista.AddRange(retorno);
            }
            return lista;
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var retorno = await MobileHelper.CallApi(HttpMethod.Put, $"{API_PESSOAS}/{item._id}", item);
            return retorno.IsSuccessStatusCode;
        }

    }
}
