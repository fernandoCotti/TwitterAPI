using Globant.Mentoring.Twitter.Models;

namespace Globant.Mentoring.Twitter.Repositories
{
    public interface IPostRepository
    {
        public Task<IEnumerable<Post>> GetAllPosts();
        public Task<IEnumerable<Post>> GetPostsFromUser(int idPost);
        public Task<IEnumerable<Post>> DeletePost(int postid);
    }
}
