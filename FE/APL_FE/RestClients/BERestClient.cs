using APL_FE.Models.Entities;
using APL_FE.Utils;
using APL_FE.Utils.IMDB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace APL_FE.RestClients
{
    public class BERestClient
    {
        private readonly WebClient _webClient;
        private string _url;

        public BERestClient()
        {
            _webClient = new WebClient();
            _webClient.Headers["Content-Type"] = "application/json;charset=UTF-8";
            _webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36");
        }

        #region Favourites API
        public bool InsertFavourite(Favourites favourite)
        {
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.favourite}";

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, favourite);

                var payload = ms.ToArray();

                //_webClient.UploadData(_url, payload);
                _webClient.UploadString(_url, WebRequestMethods.Http.Put, JsonConvert.SerializeObject(favourite));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateFavourite(Favourites favourite)
        {
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.favourite}";

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, favourite);

                var payload = ms.ToArray();

                //_webClient.UploadData(_url, payload);
                _webClient.UploadString(_url, WebRequestMethods.Http.Post, JsonConvert.SerializeObject(favourite));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Favourites> GetFavouritesByUser(User user)
        {
            string json;
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.favourites}/{user.Username}";

            json = _webClient.DownloadString(_url);

            if (string.IsNullOrEmpty(json))
                return new List<Favourites>();

            //var res = JsonConvert.DeserializeObject<FavouriteMoviesReturn>(json);
            var res = JsonConvert.DeserializeObject<List<Favourites>>(json);
            //return res.Favourites;
            return res;
        }

        public List<Favourites> GetFavouriteByMovieIdAndUser(string movieId, User user)
        {
            string json;
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.favourites}/{user.Username}/{movieId}";

            json = _webClient.DownloadString(_url);

            if (string.IsNullOrEmpty(json))
                throw new Exception("Generic error calling API");

            //var res = JsonConvert.DeserializeObject<FavouriteMoviesReturn>(json);
            var res = JsonConvert.DeserializeObject<List<Favourites>>(json);

            //if (res.Favourites.Any())
            //    return res.Favourites;
            return res;
        }
        #endregion

        #region Searches API
        public bool InsertNewSearch(UserSearches search)
        {
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.search}";
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, search);

                var payload = ms.ToArray();

                //_webClient.UploadData(_url, payload);
                _webClient.UploadString(_url, WebRequestMethods.Http.Put, JsonConvert.SerializeObject(search));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public UserSearches GetSearchByMovieId(string movieId)
        {
            try
            {
                string json;
                _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.search}/{movieId}";

                json = _webClient.DownloadString(_url);

                if (string.IsNullOrEmpty(json))
                    throw new Exception("Generic error calling API");

                var res = JsonConvert.DeserializeObject<UserSearches>(json);
                Console.WriteLine(res);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region User API
        public bool InsertNewUser(User user)
        {
            _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.user}";

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, user);

                var payload = ms.ToArray();

                //_webClient.UploadData(_url, payload);
                _webClient.UploadString(_url, WebRequestMethods.Http.Put, JsonConvert.SerializeObject(user));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                string json;
                _url = $"{Properties.Settings.Default.BE_URI}/{BEAPIEnum.user}/{username}/{password}";

                json = _webClient.DownloadString(_url);

                if (string.IsNullOrEmpty(json))
                    throw new Exception("Generic error calling API");

                var res = JsonConvert.DeserializeObject<User>(json);

                Console.WriteLine(res);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        private class FavouriteMoviesReturn
        {
            [JsonProperty("favourites")]
            public List<Favourites> Favourites { get; set; }
        }
    }
}
