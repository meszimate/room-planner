using RoomPlanner.RoomPlanner.Common.DataTransferObjects;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Data.Interfaces;
using RoomPlanner.RoomPlanner.Repository.Interfaces;
using System.Linq.Expressions;

namespace RoomPlanner.RoomPlanner.Repository
{
    public class FurnitureRepository : Repository<Furniture>, IFurnitureRepository
    {
        IFurnitureData? _furnitureData { get; set; }
        public FurnitureRepository(IFurnitureData furnitureData) : base(furnitureData)
        {
            _furnitureData = furnitureData;
        }
    }
}
