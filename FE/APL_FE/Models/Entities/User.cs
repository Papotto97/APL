using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APL_FE.Models.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")] 
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}
