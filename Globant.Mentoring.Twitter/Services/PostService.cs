using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;

namespace Globant.Mentoring.Twitter.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPosts()
        {
            var postsDTOs = new List<PostDTO>();

            var allPosts = await _postRepository.GetAllPosts();
            foreach (var post in allPosts)
            {
                postsDTOs.Add(new PostDTO
                {
                    Post_Text = post.PostText,
                    Date_Posted = post.DatePosted
                });
            }
            return postsDTOs;
        }

        public async Task<IEnumerable<PostDTO>> GetPostsFromUser(int id)
        {
            var postsDTOs = new List<PostDTO>();
            var postsFromUser = await _postRepository.GetPostsFromUser(id);
            foreach (var post in postsFromUser)
            {
                postsDTOs.Add(new PostDTO
                {
                    Post_Text = post.PostText,
                    Date_Posted = post.DatePosted
                });
            }
            return postsDTOs;
        }

        public async Task<IEnumerable<PostDTO>> PostsAfterDeletion(int id)
        {
            var postsDTOs = new List<PostDTO>();
            await _postRepository.DeletePost(id);
            var postsAfterDeletion = await _postRepository.GetAllPosts();
            foreach (var post in postsAfterDeletion)
            {
                postsDTOs.Add(new PostDTO 
                { 
                    Post_Text= post.PostText, 
                    Date_Posted= post.DatePosted
                });
            }
            return postsDTOs;
        }
    }
}
