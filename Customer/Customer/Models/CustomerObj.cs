using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Customer.Models
{
    [BsonIgnoreExtraElements]
    public class CustomerObj
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("HotelId")]
        public string HotelId { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("PhoneNo")]
        public string PhoneNo { get; set; } = string.Empty;

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("AadharPAN")]
        public string AadharPAN { get; set; } = string.Empty;

        [BsonElement("RoomType")]
        public string RoomType { get; set; } = string.Empty;

        [BsonElement("Members")]
        public int Members { get; set; }

        [BsonElement("Checkin")]
        public DateTime Checkin { get; set; }

        [BsonElement("Checkout")]
        public DateTime Checkout { get; set; }

        [BsonElement("ComplimentaryFood")]
        public Boolean ComplimentaryFood { get; set; }
    }
}
