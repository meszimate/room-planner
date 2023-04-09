using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomPlanner.RoomPlanner.Common.Entities
{
    public class Furniture : Entity
    {
        [BsonElement("Angle")]
        public int Angle { get; set; } = 0;

        [BsonElement("PositionX")]
        public int PositionX { get; set; } = 0;

        [BsonElement("PositionY")]
        public int PositionY { get; set; } = 0;
    }
}
