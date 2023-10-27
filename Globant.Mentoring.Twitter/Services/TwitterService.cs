using Globant.Mentoring.Twitter.Controllers;
using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;

namespace Globant.Mentoring.Twitter.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterRepository _twitterRepo;
        private readonly INewsService _newsService;
        public TwitterService(ITwitterRepository twitterRepository, INewsService newsService) 
        {
            _twitterRepo = twitterRepository;
            _newsService = newsService;
        }

        public async Task<IEnumerable<PostDTO>> GetHotTopics()
        {
            var hotTopics = await _twitterRepo.GetHotTopics();
            var postsDTOs = new List<PostDTO>();
            foreach (var post in hotTopics)
            {
                postsDTOs.Add(new PostDTO
                {
                    Post_Text = post.PostText,
                    Date_Posted = post.DatePosted
                });
            }
            return postsDTOs; 
        }

        public async Task<IEnumerable<PostDTO>> ShowTimeline(int userId)
        {
            var postsDTOs = new List<PostDTO>();
            for (int i = 0; i < 5; i++)
            {
                var newsToAdd = _newsService.GetNewsAsPostDTOs()[i];
                postsDTOs.Add(newsToAdd);
            }
            var userTimeline = await _twitterRepo.ShowTimeline(userId);
            foreach (var post in userTimeline)
            {
                postsDTOs.Add(new PostDTO
                {
                    Post_Text = post.PostText,
                    Date_Posted = post.DatePosted
                });
            }
            return postsDTOs;
        }

        public async Task<int> GetFollowers(int userid)
        {
                int cant = await _twitterRepo.GetFollowers(userid);
                return cant;
 
        }
    }
}
