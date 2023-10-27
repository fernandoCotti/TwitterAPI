using Dapper;
using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Globant.Mentoring.Twitter.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("/all-posts")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var postsDTOs = await _postService.GetAllPosts();
            return Ok(postsDTOs);
        }

        [HttpGet("/posts-from-user")]
        public async Task<ActionResult> GetPostsFromOneUser(int idUser)
        {
            var postsFromUser = await _postService.GetPostsFromUser(idUser);
            return Ok(postsFromUser);
        }

        [HttpDelete("post-by-id")]
        public async Task<ActionResult> PostsAfterDeletion(int idPost)
        {
            var postsAfterDeletion = await _postService.PostsAfterDeletion(idPost);
            return Ok(postsAfterDeletion);
        }
    }
}
