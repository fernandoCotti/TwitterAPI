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
    public class PostServiceTests
    {
        private IPostService _postService;
        private Mock<IPostRepository> _postRepository;

        [SetUp]
        public void SetUp()
        {
            _postRepository= new Mock<IPostRepository>();
            _postService = new PostService(_postRepository.Object);
        }

        [Test]
        public async Task GetAllPosts()
        {
            //Arrange
            _postRepository.Setup(p => p.GetAllPosts()).ReturnsAsync
                (new List<Post>
                {
                    new Post{PostText = "Lorem ipsum dolor sit amet.",DatePosted= DateTime.Now},
                    new Post{PostText = "Integer sollicitudin blandit erat, sit.", DatePosted= DateTime.Now}
                });
            //Act
            var currentPosts = await _postService.GetAllPosts();
            //Assert
            var expectedPosts = new List<PostDTO>
            {
                new PostDTO {Post_Text = "Lorem ipsum dolor sit amet.",Date_Posted= DateTime.Now},
                new PostDTO {Post_Text = "Integer sollicitudin blandit erat, sit.", Date_Posted= DateTime.Now}
            };
            Assert.That(expectedPosts.Select(t => t.Post_Text), Is.EqualTo(currentPosts.Select(t => t.Post_Text)));
        }

        [Test]
        public async Task GetPostsFromUser()
        {
            //Arrange
            //_postRepository.Setup(p => p.GetPostsFromUser(It.IsAny<int>())).ReturnsAsync
            //Act
            //Assert
        }
    }
}
