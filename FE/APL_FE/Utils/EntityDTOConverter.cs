using APL_FE.Models.Entities;
using APL_FE.Utils.IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL_FE.Utils
{
    public static class EntityDTOConverter
    {
        public static SearchData UserSearchesToSearchData(UserSearches userSearch) 
        {
            if (userSearch != null)
            {
                return new SearchData
                {
                    ErrorMessage = userSearch.ErrorMessage,
                    Expression = userSearch.Expression,

                };

            }
            return null;

        }
    }
}
