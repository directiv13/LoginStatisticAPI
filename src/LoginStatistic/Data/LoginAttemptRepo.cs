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

        public IQueryable<UserLoginAttempt> GetAttemptsForStatistic(DateTime start, DateTime end, bool? isSuccess)
        {
            return _context.LoginAttempts.Where(a => a.AttemptTime >= start && 
                                                a.AttemptTime <= end && 
                                                (isSuccess == null || a.IsSuccess == isSuccess))
                .OrderBy(s => s.AttemptTime);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
