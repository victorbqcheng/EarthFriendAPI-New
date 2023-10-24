using EarthFriendAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EarthFriendAPI.Services
{
    public class PostsService
    {
        private readonly IMongoCollection<Post> _postsCollection;
        public PostsService(MongodbService dbservice, IOptions<EarthFriendDatabaseSettings> earthFriendDatabaseSettings)
        {
            _postsCollection = dbservice.GetCollection<Post>(
                earthFriendDatabaseSettings.Value.PostsCollectionName);
        }

        public async Task<List<Post>> GetAsync() =>
            await _postsCollection.Find(_ => true).ToListAsync();

        public async Task<Post?> GetAsync(string id) =>
            await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Post newPost) =>
            await _postsCollection.InsertOneAsync(newPost);

        public async Task UpdateAsync(string id, Post updatedPost) =>
            await _postsCollection.ReplaceOneAsync(x => x.Id == id, updatedPost);

        public async Task RemoveAsync(string id) =>
            await _postsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
