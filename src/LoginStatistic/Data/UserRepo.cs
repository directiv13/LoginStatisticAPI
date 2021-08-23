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
        public IQueryable<User> Users => _context.Users;
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Remove(user);
        }
        public void DeleteUsers()
        {
            //First approach
            /*using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw(
                        String.Format(
                            "ALTER TABLE {0} DROP CONSTRAINT FK_{0}_{1}_UserId; " +
                            "TRUNCATE TABLE {0}; TRUNCATE TABLE {1}; " +
                            "ALTER TABLE {0} ADD CONSTRAINT FK_{0}_{1}_UserId FOREIGN KEY(UserId) REFERENCES {1}(Id)",
                            nameof(_context.LoginAttempts), nameof(_context.Users)
                            )
                        );
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new TransactionException($"The transaction failed, when trying to truncate {nameof(_context.Users)} and {_context.LoginAttempts} tables", e);
                }
            }*/

            //Second approach
            //_context.Database.ExecuteSqlRaw($"DELETE FROM {nameof(_context.Users)}"); 

            //Third approach
            _context.RemoveRange(_context.Users.Include(a => a.LoginAttempts));
        }
        public User GetUserByEmail(string email)
        {
            return Users.Include(a => a.LoginAttempts).FirstOrDefault(u => u.Email == email);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
