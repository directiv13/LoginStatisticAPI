using System.Collections.Generic;
using LoginStatistic.Models;

namespace LoginStatistic.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        User GetUserByEmail(string email);
        void CreateUser(User user);
        void DeleteUser(User user);
        void DeleteUsers();
    }
}
