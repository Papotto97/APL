using APL_FE.DAO.IDAO;
using APL_FE.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APL_FE.DAO
{
    public class SearchesDAO : ISearchesDAO
    {
        private readonly string _databaseName = "APL";
        private readonly string _collectionName = "Searches";
        private readonly IMongoCollection<UserSearches> _collection;

        public SearchesDAO()
        {
            var client = new MongoClient(Properties.Settings.Default.MONGO_URI);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<UserSearches>(_collectionName);
        }

        public List<UserSearches> GetSearches(string username) 
        {

            //BsonDocument filter = new BsonDocument();
            //filter.Add("username", username).Add("password", password);

            try
            {
                var res = _collection.Find(search => search.User.Equals(username)).ToList();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserSearches GetSearchById(string id)
        {

            try
            {
                var res = _collection.Find(user => user.Id == id).FirstOrDefault();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertNewSearch(UserSearches search)
        {

            try
            {
                _collection.InsertOne(search);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
