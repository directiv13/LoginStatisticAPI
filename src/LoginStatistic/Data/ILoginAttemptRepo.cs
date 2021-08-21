using System;
using System.Collections.Generic;
using LoginStatistic.Models;

namespace LoginStatistic.Data
{
    interface ILoginAttemptRepo
    {
        bool SaveChanges();
        void CreateAttempt(UserLoginAttempt attempt);
        IEnumerable<UserLoginAttempt> GetAttemptsByUserId(Guid id);
    }
}
