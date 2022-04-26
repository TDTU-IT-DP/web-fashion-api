
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace web_shop.Models
{
    public class Product
    {

        public Product() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductId { get; set; }
        public string? TypeProduct { get; set; }
        public int? Price { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; } = 0;
        public string? Size { get; set; }
        public string? Description { get; set; }
        public string? Subtitle { get; set; }
        public string? ImgLink { get; set; } = default;

    }
}
