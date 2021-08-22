using System;

namespace LoginStatistic.Dtos
{
    public class StatisticDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Metric Metric { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public enum Metric
    {
        Hour,
        Month,
        Quarter,
        Year
    }
}