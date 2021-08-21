﻿using LoginStatistic.Models;
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
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public void DeleteUsers()
        {
            _context.Database.ExecuteSqlRaw(String.Format("TRUNCATE TABLE {0}", nameof(_context.Users)));
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
