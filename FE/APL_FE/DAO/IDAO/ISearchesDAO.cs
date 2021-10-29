using APL_FE.Models.Entities;
using System.Collections.Generic;

namespace APL_FE.DAO.IDAO
{
    public interface ISearchesDAO
    {
        List<UserSearches> GetSearches(string username);

        UserSearches GetSearchById(string id);

        bool InsertNewSearch(UserSearches search);

    }
}
