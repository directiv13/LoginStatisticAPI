using AutoMapper;
using LoginStatistic.Models;
using LoginStatistic.Dtos;

namespace LoginStatistic.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserLoginAttempt, UserLoginAttemptDto>();
        }
    }
}
