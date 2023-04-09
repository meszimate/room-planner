using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Common.DataTransferObjects;
using RoomPlanner.RoomPlanner.Data.Interfaces;
using RoomPlanner.RoomPlanner.Repository.Interfaces;

namespace RoomPlanner.RoomPlanner.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private IRoomData? _roomData;
        private IFurnitureData? _furnitureData;

        public RoomRepository(IRoomData roomData, IFurnitureData furnitureData) : base(roomData)
        {
            _roomData = roomData;
            _furnitureData = furnitureData;
        }

        public async void AddFurniture(Room r, string FName)
        {
            Furniture f = (Furniture)_furnitureData._mongoCollection.Find(f => f.Name == FName);
            r.Furnitures.Add(f);
            await PushFurnitureAsync(r.Id, f);
        }

        public async void DeleteFurniture(Room r, Furniture f)
        {
            r.Furnitures.Remove(f);
            await PullFurnitureAsync(r.Id, f);
        }

        public async Task<Furniture> UpdateFurniture(string roomId, Furniture f, FurnitureDTO fdto)
        {
            Furniture newF = new Furniture()
            {
                Id = f.Id,
                Name = f.Name,
                WidthX = fdto.WidthX,
                WidthY = fdto.WidthY,
                Height = fdto.Height,
                Angle = fdto.Angle,
                PositionX = fdto.PositionX,
                PositionY = fdto.PositionY,
            };

            await UpdateFurnitureAsync(roomId, f.Id, newF);
            return newF;
        }
        //-----------------------------------------------------------------------------------------

        private async Task<UpdateResult> PushFurnitureAsync(string roomId, Furniture furniture)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.Id, roomId);
            var update = Builders<Room>.Update.Push(r => r.Furnitures, furniture);
            return await _roomData._mongoCollection.UpdateOneAsync(filter, update);
        }

        private async Task<UpdateResult> PullFurnitureAsync(string roomId, Furniture furniture)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.Id, roomId);
            var update = Builders<Room>.Update.Pull(r => r.Furnitures, furniture);
            return await _roomData._mongoCollection.UpdateOneAsync(filter, update);
        }

        private async Task<UpdateResult> UpdateFurnitureAsync(string roomId, string furnitureId, Furniture furniture)
        {
            var filter = Builders<Room>.Filter.Where(r => r.Id == roomId && r.Furnitures.Any(i => i.Id == furnitureId));
            var update = Builders<Room>.Update.Set(r => r.Furnitures[-1], furniture);
            return await _roomData._mongoCollection.UpdateOneAsync(filter, update);
        }
    }
}
