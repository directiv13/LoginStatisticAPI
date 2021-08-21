using System;
using System.Collections.Generic;
using LoginStatistic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LoginStatistic.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        [HttpGet("{email}",Name ="GetByEmail")]
        public ActionResult<UserDto> GetByEmail(string email)
        {
            return Ok(new UserDto { Id = Guid.NewGuid(), Email = "test@gmail.com", Name = "Test", Surname = "Test", LoginAttempts = new List<UserLoginAttemptDto> { new UserLoginAttemptDto { Id = Guid.NewGuid(), AttemptTime = DateTime.Now, IsSuccess = true } } });
        }
    }
}
