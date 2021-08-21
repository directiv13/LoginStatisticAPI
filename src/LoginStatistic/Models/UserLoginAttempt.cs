using System;
using System.ComponentModel.DataAnnotations;

namespace LoginStatistic.Models
{
    public class UserLoginAttempt
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime AttemptTime { get; set; }
        [Required]
        public bool IsSuccess { get; set; }
    }
}