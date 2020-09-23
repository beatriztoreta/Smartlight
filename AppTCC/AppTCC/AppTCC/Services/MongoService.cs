using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace AppTCC.Services
{
    public static class MongoService
    {
        static IMongoCollection<Person> personsCollection;
        readonly static string dbName = "dbPerson";
        readonly static string collectionName = "Person";
        static MongoClient client;

        static IMongoCollection<Person> PersonsCollection
        {
            get
            {
                if (client == null || personsCollection == null)
                {
                    var conx = "** ENTER YOUR CONNECTION STRING HERE **";
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                        new MongoUrl(conx)
                    );

                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

                    client = new MongoClient(settings);
                    var db = client.GetDatabase(dbName);

                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    personsCollection = db.GetCollection<Person>(collectionName, collectionSettings);
                }

                return personsCollection;
            }
        }

        public async static Task<List<Person>> GetAllItems()
        {
            var allItems = await PersonsCollection
                .Find(new BsonDocument())
                .ToListAsync();

            return allItems;
        }

        public async static Task<List<Person>> SearchByName(string name)
        {
            var results = await PersonsCollection
                            .AsQueryable()
                            .Where(tdi => tdi.user.Contains(name))
                            .Take(10)
                            .ToListAsync();

            return results;
        }

        public async static Task InsertItem(Person item)
        {
            await PersonsCollection.InsertOneAsync(item);
        }

        public async static Task<bool> DeleteItem(Person item)
        {
            var result = await PersonsCollection.DeleteOneAsync(tdi => tdi.id == item.id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
