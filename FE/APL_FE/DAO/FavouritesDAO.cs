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

        public Favourites GetFavouriteByMovieIdAndUser(string movieId, User user)
        {

            try
            {
                var res = _collection.Find(search => search.User.Equals(user.Username) && search.ImdbId.Equals(movieId)).FirstOrDefault();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Favourites> GetFavourites(User user)
        {

            //BsonDocument filter = new BsonDocument();
            //filter.Add("username", username).Add("password", password);

            try
            {
                var res = _collection.Find(search => search.User.Equals(user.Username)).ToList();
                Console.WriteLine(res);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertNewFavourite(string movieId, User user)
        {

            try
            {
                _collection.InsertOne(new Favourites
                {
                    ImdbId = movieId,
                    User = user
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateFavourite(string movieId, User user, string personalVote)
        {

            try
            {
                //var update = new Favourites
                //{
                //    MovieId = movieId,
                //    PersonalVote = personalVote,
                //    User = username
                //};

                var update = Builders<Favourites>.Update.Set("personalVote", personalVote);
                _collection.UpdateOne(fav => fav.ImdbId.Equals(movieId) && fav.User.Equals(user.Username), update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public Favourites GetFavouriteByMovieIdAndUser(string movieId, string username)
        //{

        //    try
        //    {
        //        var res = _collection.Find(search => search.User.Equals(username) && search.MovieId.Equals(movieId)).FirstOrDefault();
        //        Console.WriteLine(res);
        //        return res;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public List<Favourites> GetFavourites(string username)
        //{

        //    //BsonDocument filter = new BsonDocument();
        //    //filter.Add("username", username).Add("password", password);

        //    try
        //    {
        //        var res = _collection.Find(search => search.User.Equals(username)).ToList();
        //        Console.WriteLine(res);
        //        return res;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public bool InsertNewFavourite(string movieId, string username)
        //{

        //    try
        //    {
        //        _collection.InsertOne(new Favourites
        //        {
        //            MovieId = movieId,
        //            User = username
        //        });
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateFavourite(string movieId, string username, string personalVote)
        //{

        //    try
        //    {
        //        //var update = new Favourites
        //        //{
        //        //    MovieId = movieId,
        //        //    PersonalVote = personalVote,
        //        //    User = username
        //        //};

        //        var update = Builders<Favourites>.Update.Set("personalVote", personalVote);
        //        _collection.UpdateOne(fav => fav.MovieId.Equals(movieId) && fav.User.Equals(username), update);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

    }
}
