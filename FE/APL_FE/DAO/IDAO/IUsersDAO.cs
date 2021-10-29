using APL_FE.Models.Entities;

namespace APL_FE.DAO.IDAO
{
    public interface IUsersDAO
    {
        User GetUserByUsernameAndPassword(string username, string password);

        User GetUserById(string id);

    }
}
