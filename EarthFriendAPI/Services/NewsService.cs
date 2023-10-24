using EarthFriendAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EarthFriendAPI.Services
{
    public class NewsService
    {
        private readonly IMongoCollection<News> _newsCollection;
        public NewsService(MongodbService dbservice, IOptions<EarthFriendDatabaseSettings> earthFriendDatabaseSettings) 
        {
            _newsCollection = dbservice.GetCollection<News>(earthFriendDatabaseSettings.Value.NewsCollectionName);
        }

        public async Task<List<News>> GetAsync() =>
            await _newsCollection.Find(_ => true).ToListAsync();

        public async Task<News?> GetAsync(string id) =>
            await _newsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
