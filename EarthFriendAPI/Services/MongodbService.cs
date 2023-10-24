using EarthFriendAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EarthFriendAPI.Services
{
    public class MongodbService
    {
        private readonly IMongoDatabase _database;
        public MongodbService(IOptions<EarthFriendDatabaseSettings> earthFriendDatabaseSettings) 
        {
            var mongoClient = new MongoClient(
                earthFriendDatabaseSettings.Value.ConnectionString);

            _database = mongoClient.GetDatabase(
                earthFriendDatabaseSettings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}
