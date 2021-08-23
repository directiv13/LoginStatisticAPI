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

            switch(statisticCreateDto.Metric)
            {
                case (Metric.Hour):
                    return ReturnStatistic(attempts, statisticCreateDto.StartDate, statisticCreateDto.EndDate, opt => opt.AddHours(1));
                case (Metric.Month):
                    return ReturnStatistic(attempts, statisticCreateDto.StartDate, statisticCreateDto.EndDate, opt => opt.AddMonths(1));
                case (Metric.Quarter):
                    return ReturnStatistic(attempts, statisticCreateDto.StartDate, statisticCreateDto.EndDate, opt => opt.AddMonths(3));
                case (Metric.Year):
                    return ReturnStatistic(attempts, statisticCreateDto.StartDate, statisticCreateDto.EndDate, opt => opt.AddYears(1));
                default:
                    return null;
            }
        }
        public IEnumerable<StatisticResultDto> ReturnStatistic(IQueryable<UserLoginAttempt> attempts, DateTime startTime, DateTime endTime, Func<DateTime, DateTime> funcMetric)
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
