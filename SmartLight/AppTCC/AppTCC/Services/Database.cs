using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SmartLight.Models;

namespace SmartLight
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return _database.InsertAsync(person);
        }

        /*public async Task<int> DeleteItemAsync(int id)
        {
            return _database.Table<int>().DeleteAsync(id);
        }*/

    }
}
