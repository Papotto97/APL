using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APL_FE.Models.Entities
{
    [Serializable]
    public class Favourites
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("imdbId")]
        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [BsonElement("personalRating")]
        [JsonProperty("personalRating")]
        public string PersonalRating { get; set; }

        [BsonElement("user")]
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
