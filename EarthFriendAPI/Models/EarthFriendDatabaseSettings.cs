namespace EarthFriendAPI.Models
{
    public class EarthFriendDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PostsCollectionName { get; set; } = null!;
        public string NewsCollectionName { get; set; } = null!;
    }
}
