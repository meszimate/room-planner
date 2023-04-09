using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Data.Interfaces;

namespace RoomPlanner.RoomPlanner.Data
{
    public class RoomData : MongoDBData<Room>, IRoomData
    {
        public RoomData(IConfiguration config) : base(config)
        {
        }
    }
}
