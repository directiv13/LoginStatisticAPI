using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginStatistic.Data;
using LoginStatistic.Models;

namespace LoginStatistic.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        public UserController(IUserRepo repository)
        {
            _repo = repository;
        }

        [HttpPost]
        public ActionResult Init(int amount)
        {
            _repo.DeleteUsers();
            for (int i = 0; i < amount; i++)
            {
                Guid userGuid = Guid.NewGuid();
                _repo.CreateUser(new User { Id = userGuid, Email = $"user{amount}@gmail.com" });
                List<UserLoginAttempt> attempts = new List<UserLoginAttempt>();

            }
            return Ok();
        }
    }
}
