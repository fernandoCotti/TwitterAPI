using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;

namespace Globant.Mentoring.Twitter.Services
{
    public interface ITwitterService
    {
        public Task<IEnumerable<PostDTO>> GetHotTopics();
        public Task<IEnumerable<PostDTO>> ShowTimeline(int userId);
        public Task<int> GetFollowers(int userid);
    }
}
