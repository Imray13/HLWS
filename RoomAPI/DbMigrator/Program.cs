using MongoDB.Driver;
using RoomAPI;

namespace DbMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();

            var db = client.GetDatabase(Constants.DbName);

            db.DropCollection(Constants.TableCollectionName);
            db.CreateCollection(Constants.TableCollectionName);

            db.DropCollection(Constants.PlayerCollectionName);
            db.CreateCollection(Constants.PlayerCollectionName);
        }
    }
}
