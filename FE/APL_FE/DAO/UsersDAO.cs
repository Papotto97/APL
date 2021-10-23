using APL_FE.Models;
using APL_FE.Models.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL_FE.DAO
{
    public class UsersDAO
    {
        private readonly string _databaseName = "APL";
        private readonly string _collectionName = "Users";
        private readonly IMongoCollection<User> _collection;

        public UsersDAO()
        {
            var client = new MongoClient(Properties.Settings.Default.MONGO_URI);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<User>(_collectionName);
        }

        public User GetUserByUsernameAndPassword(string username, string password) 
        {

            //BsonDocument filter = new BsonDocument();
            //filter.Add("username", username).Add("password", password);

            try
            {
                var res = _collection.Find(user => user.Username == username && user.Password == password).FirstOrDefault();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUserById(string id)
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

    }
}
