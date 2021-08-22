using LoginStatistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoginStatistic.Exceptions;

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
        public void DeleteUsers()
        {
            using (var transaction = _context.Database.BeginTransaction())
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
            }
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
