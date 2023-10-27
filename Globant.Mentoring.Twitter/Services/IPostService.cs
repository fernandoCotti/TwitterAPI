using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;

namespace Globant.Mentoring.Twitter.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDTO>> GetPostsFromUser(int userid);
        public Task<IEnumerable<PostDTO>> GetAllPosts();
        public Task<IEnumerable<PostDTO>> PostsAfterDeletion(int id);

    }
}
