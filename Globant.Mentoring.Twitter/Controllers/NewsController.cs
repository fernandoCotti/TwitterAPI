using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using Globant.Mentoring.Twitter.Services;
using Globant.Mentoring.Twitter.DTOs;

namespace Globant.Mentoring.Twitter.Controllers
{
    [Route("api/v1/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostDTO>> GetNewsAsPostDTOs()
        {
            var postsDTO = _newsService.GetNewsAsPostDTOs();
            return Ok(postsDTO);
        }
    }
}
