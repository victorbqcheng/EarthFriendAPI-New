using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EarthFriendAPI.Models
{
    public class News
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;

        [BsonElement("title")]
        public string Title { get; set; } = null!;

        [BsonElement("author")]
        public string Author { get; set; } = null!;

        [BsonElement("content")]
        public string Content { get; set; } = null!;

        [BsonElement("date")]
        public string Date { get; set; } = null!;

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; } = null;

    }
}
