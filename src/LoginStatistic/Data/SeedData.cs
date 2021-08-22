using System;
using Microsoft.EntityFrameworkCore;
using LoginStatistic.Models;
using System.Collections.Generic;

namespace LoginStatistic.Data
{
    public static class SeedData
    {
        private static DateTimeGenerator generator;
        public static void EnsurePopulated(IUserRepo repo, int amount)
        {
            repo.DeleteUsers();

            Random randGen = new Random();
            for(int i = 0; i < amount; i++)
            {
                User user = new User { Email = $"user{i}@gmail.com", Name = $"user{i}", Surname = $"surname{i}" };
                
                List<UserLoginAttempt> attempts = new List<UserLoginAttempt>();
                int attemptsNumber = randGen.Next(0, 20);
                generator = new DateTimeGenerator();
                for(int j = 0; j < attemptsNumber; j++)
                {
                    attempts.Add(new UserLoginAttempt { AttemptTime = generator.Next(), IsSuccess = randGen.Next(0, 2) == 0 ? false : true });
                }
                user.LoginAttempts = attempts;

                repo.CreateUser(user);
            }
        }
    }
}
