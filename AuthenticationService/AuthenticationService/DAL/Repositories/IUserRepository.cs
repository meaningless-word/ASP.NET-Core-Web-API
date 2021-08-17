using AuthenticationService.BLL.Models;
using System.Collections.Generic;

namespace AuthenticationService.DAL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
