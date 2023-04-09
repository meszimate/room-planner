using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomPlanner.RoomPlanner.Common.Entities
{
    public class Room : Entity
    {
        [BsonElement("Furnitures")]
        public List<Furniture>? Furnitures { get; set; } = new List<Furniture>();
    }
}
