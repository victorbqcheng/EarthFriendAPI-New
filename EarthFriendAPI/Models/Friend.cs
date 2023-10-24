using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EarthFriendAPI.Models
{
    public class Friend
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null;

        [BsonElement("name")]
        public string Name { get; set; } = null!;
        [BsonElement("content")]
        public string Content { get; set; } = null!;
        [BsonElement("photo")]
        public string Photo { get; set; } = null!;
        [BsonElement("date")]
        public string Date { get; set; } = null!;
    }
}
