using MongoDB.Driver;
using RoomAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomAPI.DAL
{
    public class TableService
    {
        private readonly IMongoCollection<Table> _tableCollection;

        public TableService()
        {
            var client = new MongoClient();

            var db = client.GetDatabase(Constants.DbName);

            _tableCollection = db.GetCollection<Table>(Constants.TableCollectionName);
        }


        public async Task Create(Table table)
        {
            await _tableCollection.InsertOneAsync(table);
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            var result = await _tableCollection.FindAsync(_ => true);
            var resultList = await result.ToListAsync();

            return resultList;
        }

        public async Task<Table> GetAsync(string name)
        {
            var result = await _tableCollection.FindAsync(t => t.Name == name);
            var resultTable = await result.SingleAsync();

            return resultTable;
        }

        public async Task DeleteAsync(string name)
        {
            await _tableCollection.DeleteOneAsync(t => t.Name == name);
        }
    }
}
