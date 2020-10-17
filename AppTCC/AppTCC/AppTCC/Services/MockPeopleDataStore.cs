using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AppTCC.Models;

namespace AppTCC.Services
{
    public class MockPeopleDataStore : IDataStore<Person>
    {
        readonly List<Person> items;

        public MockPeopleDataStore()
        {
            items = new List<Person>()
            {
                new Person { _id = Guid.NewGuid().ToString(), user = "First", password = "One" },
                new Person { _id = Guid.NewGuid().ToString(), user = "Second", password = "Two" },
                new Person { _id = Guid.NewGuid().ToString(), user = "Third", password = "Three" },
                new Person { _id = Guid.NewGuid().ToString(), user = "Fourth", password = "Four" },
                new Person { _id = Guid.NewGuid().ToString(), user = "Fifth", password = "Five" },
                new Person { _id = Guid.NewGuid().ToString(), user = "Sixth", password = "Six" }
            };
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var oldItem = items.FirstOrDefault((Person arg) => arg._id == item._id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault((Person arg) => arg._id.ToString() == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s._id.ToString() == id));
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
    }
}
