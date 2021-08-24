using LoginStatistic.Data;
using LoginStatistic.Dtos;
using AutoMapper;

namespace LoginStatistic
{
    public class UserManager
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public UserManager(IUserRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public void PopulateData(int amount)
        {
            SeedData.EnsurePopulated(_repo, amount);
            _repo.SaveChanges();
        }
        public UserDto GetUserByEmail(string email)
        {
            return _mapper.Map<UserDto>(_repo.GetUserByEmail(email));
        }
    }
}
