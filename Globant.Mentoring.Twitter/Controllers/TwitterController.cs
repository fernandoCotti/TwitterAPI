using Dapper;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Globant.Mentoring.Twitter.Services;

namespace Globant.Mentoring.Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ITwitterService _twitterService;
        private readonly INewsService _newsService;
        public TwitterController(ITwitterService twitterService, INewsService newsService)
        {
            _twitterService = twitterService;
            _newsService = newsService;
        }
        [HttpGet("/topics")]
        public async Task<IActionResult> GetTopics()
        {
            var hotTopics = await _twitterService.GetHotTopics();
            return Ok(hotTopics);  
        }
        [HttpGet("/timeline-of-user")]
        public async Task<IActionResult> ShowTimelineOfUser(int userID)
        {
            var postsDTOs = await _twitterService.ShowTimeline(userID);
            return Ok(postsDTOs);
        }

        [HttpGet("/followers-of-user")]
        public async Task<IActionResult> AmountOfFollowers(int userID)
        {
            var followers = await _twitterService.GetFollowers(userID);
            return Ok(followers);
        }
    }
}
