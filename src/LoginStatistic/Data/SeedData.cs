using System;
using Microsoft.EntityFrameworkCore;
using LoginStatistic.Models;
using System.Collections.Generic;

namespace LoginStatistic.Data
{
    public static class SeedData
    {
        private static DateTimeGenerator generator;
        public static void EnsurePopulated(LoginContext context, int amount)
        {
            Random randGen = new Random();

            context.Database.ExecuteSqlRaw(String.Format("ALTER TABLE {0} DROP CONSTRAINT FK_LoginAttempts_Users_UserId; TRUNCATE TABLE {0}; TRUNCATE TABLE {1}; ALTER TABLE {0} ADD CONSTRAINT FK_LoginAttempts_Users_UserId FOREIGN KEY(UserId) REFERENCES {1}(Id)", nameof(context.LoginAttempts), nameof(context.Users)));

            List<User> users = new List<User>();
            for(int i = 0; i < amount; i++)
            {
                Guid userId = Guid.NewGuid();
                users.Add(new User { Id = userId, Email = $"user{i}@gmail.com", Name = $"user{i}", Surname = $"surname{i}" });
                
                List<UserLoginAttempt> attempts = new List<UserLoginAttempt>();
                int attemptsNumber = randGen.Next(0, 20);
                generator = new DateTimeGenerator();
                for(int j = 0; j < attemptsNumber; j++)
                {
                    attempts.Add(new UserLoginAttempt { AttemptTime = generator.Next(), IsSuccess = randGen.Next(0, 2) == 0 ? false : true });
                }
                users[i].LoginAttempts = attempts;
            }
            context.AddRange(users);

            context.SaveChanges();
        }
    }
}
