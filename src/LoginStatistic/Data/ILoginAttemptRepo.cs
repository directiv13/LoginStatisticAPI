using System;
using System.Collections.Generic;
using System.Linq;
using LoginStatistic.Models;

namespace LoginStatistic.Data
{
    public interface ILoginAttemptRepo
    {
        bool SaveChanges();
        void CreateAttempt(UserLoginAttempt attempt);
        IEnumerable<UserLoginAttempt> GetAttemptsByUserId(Guid id);
        IQueryable<UserLoginAttempt> GetAttemptsForStatistic(DateTime start, DateTime end, bool? isSuccess);
    }
}
