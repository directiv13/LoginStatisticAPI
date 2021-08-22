using LoginStatistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoginStatistic.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly LoginContext _context;
        public UserRepo(LoginContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(user);
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(x => x.Email == email).Include(a => a.LoginAttempts).FirstOrDefault();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
