using APL_FE.Models.Entities;
using System.Collections.Generic;

namespace APL_FE.DAO.IDAO
{
    public interface IFavouritesDAO
    {
        List<Favourites> GetFavourites(User user);

        Favourites GetFavouriteByMovieIdAndUser(string movieId, User user);

        bool InsertNewFavourite(string movieId, User user);

        bool UpdateFavourite(string movieId, User user, string personalVote);

        //List<Favourites> GetFavourites(string username);

        //Favourites GetFavouriteByMovieIdAndUser(string movieId, string username);

        //bool InsertNewFavourite(string movieId, string username);

        //bool UpdateFavourite(string movieId, string username, string personalVote);

    }
}
