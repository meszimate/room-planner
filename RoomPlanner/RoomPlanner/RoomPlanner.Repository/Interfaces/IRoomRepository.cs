using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Common.DataTransferObjects;
using RoomPlanner.RoomPlanner.Common.Entities;

namespace RoomPlanner.RoomPlanner.Repository.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        public void AddFurniture(Room r, string FName);

        public void DeleteFurniture(Room r, Furniture f);

        public Task<Furniture> UpdateFurniture(string roomId, Furniture f, FurnitureDTO fdto);
    }
}
