using MongoDB.Driver;
using RoomAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomAPI.DAL
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _playerCollection;

        public PlayerService()
        {
            var client = new MongoClient();

            var db = client.GetDatabase(Constants.DbName);

            _playerCollection = db.GetCollection<Player>(Constants.PlayerCollectionName);
        }


        public async Task Create(Player player)
        {
            await _playerCollection.InsertOneAsync(player);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            var result = await _playerCollection.FindAsync(_ => true);
            var resultList = await result.ToListAsync();

            return resultList;
        }

        public async Task<Player> GetAsync(string name)
        {
            var result = await _playerCollection.FindAsync(t => t.Name == name);
            var resultPlayer = await result.SingleAsync();

            return resultPlayer;
        }

        public async Task DeleteAsync(string name)
        {
            await _playerCollection.DeleteOneAsync(t => t.Name == name);
        }

        public async Task UpdateBalance(string name, double newBalance)
        {
            var updateDefinition = Builders<Player>
                .Update
                .Set(p => p.AvailableFunds, newBalance);

            await _playerCollection.UpdateOneAsync(p => p.Name == name, updateDefinition);
        }
    }
}
