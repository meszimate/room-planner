using MongoDB.Driver;

namespace RoomPlanner.RoomPlanner.Data.Interfaces
{
    public interface IMongoDBData<T>
    {
        public IMongoCollection<T> _mongoCollection { get; set; }
    }
}