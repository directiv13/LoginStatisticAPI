using System.Collections.Generic;
using System.Linq;
using LoginStatistic.Models;

namespace LoginStatistic.Data
{
    public interface IUserRepo
    {
        IQueryable<User> Users { get; }
        bool SaveChanges();
        User GetUserByEmail(string email);
        void CreateUser(User user);
        void DeleteUser(User user);
        void DeleteUsers();
    }
}
