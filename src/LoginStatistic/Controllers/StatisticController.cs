using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginStatistic.Dtos;
using LoginStatistic.Data;

namespace LoginStatistic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController: ControllerBase
    {
        private StatisticBuilder statisticBuilder;
        public StatisticController(ILoginAttemptRepo repository)
        {
            statisticBuilder = new StatisticBuilder(repository);
        }
        [HttpPost]
        public ActionResult<IEnumerable<StatisticResultDto>> GetStatistic(StatisticCreateDto statisticCreateDto)
        {
            return Ok(statisticBuilder.GetStatistic(statisticCreateDto));
        }
    }
}