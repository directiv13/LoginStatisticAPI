using System;
using System.Collections.Generic;
using LoginStatistic.Data;
using LoginStatistic.Models;
using LoginStatistic.Dtos;
using System.Linq;

namespace LoginStatistic
{
    public class StatisticBuilder
    {
        private readonly ILoginAttemptRepo _repo;
        public StatisticBuilder(ILoginAttemptRepo repository)
        {
            _repo = repository;
        }

        public IEnumerable<StatisticResultDto> GetStatistic(StatisticCreateDto statisticCreateDto)
        {
            IQueryable<UserLoginAttempt> attempts = _repo.GetAttemptsForStatistic(statisticCreateDto.StartDate, statisticCreateDto.EndDate, statisticCreateDto.IsSuccess);

            Func<DateTime, DateTime> funcMetric;
            switch(statisticCreateDto.Metric)
            {
                case (Metric.Hour):
                    funcMetric = opt => opt.AddHours(1);
                    break;
                case (Metric.Month):
                    funcMetric = opt => opt.AddMonths(1);
                    break;
                case (Metric.Quarter):
                    funcMetric = opt => opt.AddMonths(3);
                    break;
                case (Metric.Year):
                    funcMetric = opt => opt.AddYears(1);
                    break;
                default:
                    return null;
            }
            return CollectStatistic(attempts, statisticCreateDto.StartDate, statisticCreateDto.EndDate, funcMetric);
        }
        private IEnumerable<StatisticResultDto> CollectStatistic(IQueryable<UserLoginAttempt> attempts, DateTime startTime, DateTime endTime, Func<DateTime, DateTime> funcMetric)
        {
            List<StatisticResultDto> statisticResults = new List<StatisticResultDto>();
            DateTime currentEnd = funcMetric(startTime);
            for(DateTime currentStart = startTime; currentEnd <= endTime; currentStart = funcMetric(currentStart), currentEnd = funcMetric(currentEnd))
            {
                statisticResults.Add(new StatisticResultDto { Period = currentStart, Value = attempts.Where(a => a.AttemptTime >= currentStart && a.AttemptTime <= currentEnd).Count() });
            }
            return statisticResults;
        }
    }
}
