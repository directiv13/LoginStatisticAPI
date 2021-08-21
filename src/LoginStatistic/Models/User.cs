using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginStatistic.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(25)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        public List<UserLoginAttempt> LoginAttempts { get; set; }
    }
}