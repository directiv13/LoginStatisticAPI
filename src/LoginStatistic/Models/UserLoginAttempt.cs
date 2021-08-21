using System;
using System.ComponentModel.DataAnnotations;

namespace LoginStatistic.Models
{
    public class UserLoginAttempt
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime AttemptTime { get; set; }
        [Required]
        public bool IsSuccess { get; set; }
        public Guid UserId { get; set; }
    }
}