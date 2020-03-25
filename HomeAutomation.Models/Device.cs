using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeAutomation.Models
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string DeviceName { get; set; }
        public string ApplianceId { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
    }
}
