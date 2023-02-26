using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Admin.Models
{
    [BsonIgnoreExtraElements]
    public class Hotel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("HotelName")]
        public string HotelName { get; set;} = string.Empty;

        [BsonElement("Location")]
        public string Location { get; set; } = string.Empty;

        [BsonElement("RoomTypes")]
        public string RoomTypes { get; set; } = string.Empty;

        [BsonElement("ComplimentaryFood")]
        public Boolean ComplimentaryFood { get; set; }

        [BsonElement("Prices")]
        public string Prices { get; set; } = string.Empty;
    }
}
