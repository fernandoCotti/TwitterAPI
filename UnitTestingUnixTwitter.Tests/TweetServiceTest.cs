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
    public class TweetServiceTest
    {
        private ITwitterService _twitterService;
        private Mock<ITwitterRepository> _twitterRepository;
        private Mock<INewsService> _newsService;

        [SetUp]
        public void SetUp()
        {
            _twitterRepository = new Mock<ITwitterRepository>();
            _newsService = new Mock<INewsService>();
            _twitterService = new TwitterService(_twitterRepository.Object, _newsService.Object);    
        }

        [Test]
        public async Task GetHotTopics()
        {
            //Arrange
            _twitterRepository.Setup(t => t.GetHotTopics()).ReturnsAsync
                (new List<Post>
                {
                    new Post{PostText = "Lorem ipsum dolor sit amet.",DatePosted= DateTime.Now},
                    new Post{PostText = "Integer sollicitudin blandit erat, sit.", DatePosted= DateTime.Now}
                });
            //Act
            var currentPosts = await _twitterService.GetHotTopics();
            //Assert
            var expectedPosts = new List<PostDTO>
            {
                new PostDTO{Post_Text = "Lorem ipsum dolor sit amet.",Date_Posted= DateTime.Now},
                new PostDTO{Post_Text = "Integer sollicitudin blandit erat, sit.", Date_Posted= DateTime.Now}
            };
            Assert.AreEqual(expectedPosts.Count, currentPosts.Count());
            Assert.That(expectedPosts.First().Post_Text.Equals(currentPosts.First().Post_Text));

        }

        [Test]
        public async Task GetFollowers()
        {
            //Arrange
            _twitterRepository.Setup(t => t.GetFollowers(It.IsAny<int>())).ReturnsAsync
                (
                )
            //Act
            //Assert
        }


    }
}
