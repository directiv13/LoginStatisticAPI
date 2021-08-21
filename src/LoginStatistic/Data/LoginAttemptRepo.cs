using LoginStatistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginStatistic.Data
{
    public class LoginAttemptRepo : ILoginAttemptRepo
    {
        private readonly LoginContext _context;
        public LoginAttemptRepo(LoginContext context)
        {
            _context = context;
        }
        public void CreateAttempt(UserLoginAttempt attempt)
        {
            if(attempt == null)
            {
                throw new ArgumentNullException();
            }
            _context.LoginAttempts.Add(attempt);
        }

        public IEnumerable<UserLoginAttempt> GetAttemptsByUserId(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id)?.LoginAttempts;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
