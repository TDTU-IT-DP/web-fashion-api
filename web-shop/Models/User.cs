﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace web_shop.Models
{
    public class User
    {
        public User() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int TypeUser { get; set; }
    }
}
