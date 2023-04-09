using MongoDB.Driver;
using RoomPlanner.RoomPlanner.Common.Entities;
using RoomPlanner.RoomPlanner.Common.DataTransferObjects;
using RoomPlanner.RoomPlanner.Data.Interfaces;
using RoomPlanner.RoomPlanner.Repository.Interfaces;

namespace RoomPlanner.RoomPlanner.Repository
{
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {
        private IMongoDBData<T> _mongoDBData { get; set; }

        public Repository(IMongoDBData<T> mongoDBData)
        {
            _mongoDBData = mongoDBData;
        }

        public async Task<T> Create(EntityDTO edto)
        {
            T e = (T)(new Entity()
            {
                Name = edto?.Name,
                WidthX = edto.WidthX,
                WidthY = edto.WidthY,
                Height = edto.Height,
            });
            await _mongoDBData._mongoCollection.InsertOneAsync(e);
            return e;
        }

        public async Task<Entity> Get(string id)
        {
            return await _mongoDBData._mongoCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _mongoDBData._mongoCollection.Find(e => true).ToListAsync();
        }

        public async Task<T> Update(T e, EntityDTO edto)
        {
            T newEntity = (T)(new Entity()
            {
                Id = e.Id,
                Name = edto?.Name,
                WidthX = edto.WidthX,
                WidthY = edto.Height,
                Height = edto.Height
            });

            await _mongoDBData._mongoCollection.ReplaceOneAsync(en => en.Id == e.Id, newEntity);
            return newEntity;
        }

        public async Task Delete(string id)
        {
            await _mongoDBData._mongoCollection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
