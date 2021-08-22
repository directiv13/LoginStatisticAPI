using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginStatistic.Dtos;

namespace LoginStatistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController: ControllerBase
    {
        [HttpPost]
        public ActionResult<IEnumerable<StatisticResultDto>> GetStatistic(StatisticCreateDto statisticCreateDto)
        {
            
        }
    }
}