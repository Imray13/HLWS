using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomAPI.Models
{
    public class Table
    {
        [BsonId]
        public string Name { get; set; }

        public int MaxPlayers { get; set; }

        public double MinBuyIn { get; set; }

        public Dictionary<string, double> CurrentPlayers { get; set; }
    }
}
