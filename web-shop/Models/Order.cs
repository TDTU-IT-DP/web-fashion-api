using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace web_shop.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public List<productCart>? productCart { get; set; }
        public int totalPrice { get; set; }
        public string? CusName { get; set; }
        public string? Status { get; set; } = "Chờ duyệt đơn";
        public int? CusConfirm { get; set; } = 0;
        public int? AdminConfirm { get; set; } = 0;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
    }
}
