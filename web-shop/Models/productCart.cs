using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace web_shop.Models
{
    public class productCart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }

        public int amount { get; set; } = 1;
    }
}
