using APL_FE.Models.Entities;
using System.Collections.Generic;

namespace APL_FE.DAO.IDAO
{
    public interface IFavouritesDAO
    {
        List<Favourites> GetFavourites(string username);

        Favourites GetFavouriteByMovieIdAndUser(string movieId, string username);

        bool InsertNewFavourite(string movieId, string username);

        bool UpdateFavourite(string movieId, string username, string personalVote);

    }
}
