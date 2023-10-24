using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EarthFriendAPI.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;

        [BsonElement("title")]
        public string Title { get; set; } = null!;
        [BsonElement("description")]
        public string Description { get; set; } = null!;

        public string? imageUrl { get; set; } = null;
    }
}
