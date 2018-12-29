using MongoDB.Bson.Serialization.Attributes;

namespace RoomAPI.Models
{
    public class Player
    {
        [BsonId]
        public string Name { get; set; }
        
        public double AvailableFunds { get; set; }
    }
}
