using System;

namespace LoginStatistic.Models
{
    public class UserLoginAttempt
    {
        public Guid Id { get; set; }
        public DateTime AttemptTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}