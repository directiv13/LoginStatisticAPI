using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginStatistic.Dtos
{
    public class UserLoginAttemptDto
    {
        public DateTime AttemptTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}
