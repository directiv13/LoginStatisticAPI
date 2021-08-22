using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginStatistic.Data;
using LoginStatistic.Models;

namespace LoginStatistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly LoginContext _context;
        public UserController(IUserRepo repository, LoginContext context)
        {
            _repo = repository;
            _context = context;
        }

        [HttpPost("{amount}", Name = "Init")]
        public ActionResult Init(int amount)
        {
            SeedData.EnsurePopulated(_context, amount);
            return Ok("Hello, wolrd");
        }

        [HttpGet("{email}", Name = "GetByEmail")]
        public ActionResult<User> GetByEmail(string email)
        {
            return Ok(_repo.GetUserByEmail(email));
        }
    }
}
