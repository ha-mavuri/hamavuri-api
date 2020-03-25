using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeAutomation.Models
{
    public class Appliance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string ApplianceName { get; set; }
        public bool IsContinousOn { get; set; }
        public bool IsHighVoltageRequired { get; set; }
        public bool IsActive { get; set; }
    }
}
