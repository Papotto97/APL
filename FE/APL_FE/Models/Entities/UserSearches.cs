using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace APL_FE.Models.Entities
{
    public class UserSearches
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("searchType")]
        public string SearchType { get; set; }

        [BsonElement("expression")]
        public string Expression { get; set; }

        [BsonElement("movieId")]
        public string MovieId { get; set; }

        [BsonElement("movieTitle")]
        public string MovieTitle { get; set; }

        [BsonElement("errorMessage")]
        public string ErrorMessage { get; set; }

        [BsonElement("user")]
        public string User { get; set; }
    }
}
