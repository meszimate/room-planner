using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Common.DataTransferObjects;
using RoomPlanner.RoomPlanner.Data.Interfaces;

namespace RoomPlanner.RoomPlanner.Repository.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        public abstract Task<T> Create(EntityDTO edto);

        public Task<T> Update(T r, EntityDTO edto);

        public Task<List<T>> GetAll();

        public Task<Entity> Get(string id);

        public Task Delete(string id);
    }
}
