using APL_FE.DAO.IDAO;
using APL_FE.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APL_FE.DAO
{
    public class FavouritesDAO : IFavouritesDAO
    {
        private readonly string _databaseName = "APL";
        private readonly string _collectionName = "Favourites";
        private readonly IMongoCollection<Favourites> _collection;

        public FavouritesDAO()
        {
            var client = new MongoClient(Properties.Settings.Default.MONGO_URI);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<Favourites>(_collectionName);
        }

        public Favourites GetFavouriteByMovieIdAndUser(string movieId, string username)
        {

            try
            {
                var res = _collection.Find(search => search.User.Equals(username) && search.MovieId.Equals(movieId)).FirstOrDefault();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Favourites> GetFavourites(string username)
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

        public bool InsertNewFavourite(string movieId, string username)
        {

            try
            {
                _collection.InsertOne(new Favourites
                {
                    MovieId = movieId,
                    User = username
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
