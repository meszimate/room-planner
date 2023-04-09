using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Data.Interfaces;

namespace RoomPlanner.RoomPlanner.Data
{
    public class FurnitureData : MongoDBData<Furniture>, IFurnitureData
    {
        public FurnitureData(IConfiguration config) : base(config)
        {
        }
    }
}
