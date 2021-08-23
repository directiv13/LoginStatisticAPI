using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LoginStatistic.Data;
using LoginStatistic.Profiles;
using System;

namespace LoginStatistic.Tests
{
    public class UserManagerTests: IDisposable
    {
        Mock<IUserRepo> mockRepo;
        UserProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public UserManagerTests()
        {
            mockRepo = new Mock<IUserRepo>();
            realProfile = new UserProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetUserByEmail_ReturnsNull_WhenUserNotFound()
        {
            Mock<IUserRepo> mock = new Mock<IUserRepo>();
            mock.Setup(m => m.GetUserByEmail(string.Empty)).Returns(() => null);

            UserManager manager = new UserManager(mock.Object, mapper);

            var result = manager.GetUserByEmail(string.Empty);

            Assert.Null(result);
        }
    }
}
