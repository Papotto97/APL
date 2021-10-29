using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace APL_FE.Models.Entities
{
    public class Favourites
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("movieId")]
        public string MovieId { get; set; }

        [BsonElement("user")]
        public string User { get; set; }
    }
}
