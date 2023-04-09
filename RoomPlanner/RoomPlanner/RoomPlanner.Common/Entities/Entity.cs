using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomPlanner.RoomPlanner.Common.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("WidthX")]
        public int WidthX { get; set; }

        [BsonElement("WidthY")]
        public int WidthY { get; set; }

        [BsonElement("Height")]
        public int Height { get; set; }
    }
}
