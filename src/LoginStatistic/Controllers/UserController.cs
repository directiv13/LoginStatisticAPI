using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LoginStatistic.Data;
using LoginStatistic.Dtos;

namespace LoginStatistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager manager;
        public UserController(IUserRepo repository, IMapper mapper)
        {
            manager = new UserManager(repository, mapper);
        }

        [HttpPost("{amount}", Name = "Init")]
        public void Init(int amount)
        {
            manager.PopulateData(amount);
        }

        [HttpGet("{email}", Name = "GetByEmail")]
        public ActionResult<UserDto> GetByEmail(string email)
        {
            UserDto userDto = manager.GetUserByEmail(email);

            return userDto != null ? userDto : NotFound();
        }
    }
}
