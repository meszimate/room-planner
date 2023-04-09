using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Data.Interfaces;

namespace RoomPlanner.RoomPlanner.Data
{
    public abstract class MongoDBData<T> : IMongoDBData<T>
    {
        public IMongoCollection<T> _mongoCollection { get; set; }
        public MongoDBData(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("RoomPlannerDB"));
            // Gets the DB.
            var database = client.GetDatabase("RoomPlannerDB");
            //Fetches the collection.
            var collectionName = $"{typeof(T).ToString().Split('.').Last()}s";
            _mongoCollection = database.GetCollection<T>(collectionName);
        }
    }
}
