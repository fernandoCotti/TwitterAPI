using Globant.Mentoring.Twitter.Models;

namespace Globant.Mentoring.Twitter.Repositories
{
    public interface ITwitterRepository
    {
        public Task<IEnumerable<Post>> GetHotTopics();
        public Task<IEnumerable<Post>> ShowTimeline(int userId);
        public Task<int> GetFollowers(int userid);
    }
}
