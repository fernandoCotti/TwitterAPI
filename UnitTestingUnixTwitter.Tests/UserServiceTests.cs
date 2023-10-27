using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingUnixTwitter.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public async Task GetUserById()
        {
            //Arrange
            _userRepository.Setup(u => u.GetUser(It.IsAny<int>())).ReturnsAsync
                (new User { UserId = 1, Username = "miguel2009" });
            //Act
            var currentUser = await _userService.GetUserByID(1);
            //Assert
            var expectedUser = new UserDTO { Username = "miguel2009" };
            Assert.IsTrue(currentUser.Username.Equals(expectedUser.Username));
        }

        [Test]
        public async Task GetAllUsers()
        {
            //Arrange
            _userRepository.Setup(u => u.GetAllUsers()).ReturnsAsync
                (new List<User>
                {
                    new User { UserId = 1, Username = "miguel2009" },
                    new User { UserId = 2, Username = "juanceto01" }
                });
            //Act
            var currentUsers = await _userService.GetAllUsers();
            //Assert
            var expectedUsers = new List<UserDTO>
            {
                new UserDTO{ Username = "miguel2009" },
                new UserDTO{ Username = "juanceto01" }
            };
            Assert.That(expectedUsers.Select(u => u.Username), Is.EqualTo(currentUsers.Select(u => u.Username)));

        }

        [Test]
        public async Task CreateUser()
        {
            //Arrange
            _userRepository.Setup(u => u.CreateUser(It.IsAny<CreateUserDTO>())).ReturnsAsync
                (new List<User>
                {
                    new User { Username = "juanceto01" }
                });
            _userRepository.Setup(u => u.GetAllUsers()).ReturnsAsync
                (new List<User>
                {
                    new User { Username = "juanceto01" }
                });
            //Act
            var currentUsers = await _userService.UsersAfterCreation(new CreateUserDTO
            {
                Username = "juanceto01"
            });
            //Assert
            var expectedUser = new List<CreateUserDTO>
            {
                new CreateUserDTO{ Username = "juanceto01" }
            };
            Assert.IsTrue(expectedUser.First().Username.Equals(currentUsers.First().Username));
        }

        [Test]
        public async Task DeleteUser()
        {
            //Arrange
           // _userRepository.Setup(u => u.DeleteUser(It.IsAny<int>())).ReturnsAsync
           //     (new User { Username = "juanceto01" });
            //Act
           // var currentUser
            //Assert
        }
    }
}
