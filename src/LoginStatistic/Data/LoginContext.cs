using Microsoft.EntityFrameworkCore;
using LoginStatistic.Models;

namespace LoginStatistic.Data
{
    public class LoginContext: DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            :base(options)
        {        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoginAttempt> LoginAttempts { get; set; }
    }
}
