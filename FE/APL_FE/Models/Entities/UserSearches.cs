using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APL_FE.Models.Entities
{
    [Serializable]
    public class UserSearches
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("searchType")]
        [JsonProperty("searchType")]
        public string SearchType { get; set; }

        [BsonElement("expression")]
        [JsonProperty("expression")]
        public string Expression { get; set; }

        [BsonElement("imdbId")]
        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [BsonElement("movieTitle")]
        [JsonProperty("movieTitle")]
        public string MovieTitle { get; set; }

        [BsonElement("errorMessage")]
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [BsonElement("user")]
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
