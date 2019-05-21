using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DinamicDataMvc.Models
{
    public class DataModel
    {
        [BsonId]
        [BsonRequired]
        public string Id { get; set; }
        [BsonElement]
        public string DataType { get; set; }
        [BsonElement]
        public string Field { get; set; }
        [BsonElement]
        public int Size { get; set; }
        [BsonElement]
        public bool Mandatory { get; set; }
        [BsonElement]
        public bool BreakLine { get; set; }
    }
}
