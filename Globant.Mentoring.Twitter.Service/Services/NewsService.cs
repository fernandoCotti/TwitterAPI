using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.DTOs;

namespace Globant.Mentoring.Twitter.Services
{
    public class NewsService : INewsService
    {

        public NewsService(){}

        public List<PostDTO> GetNewsAsPostDTOs()
        {
            var newsApiClient = new NewsApiClient("4175a1c587984e299135fad8af501d14");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.Now.AddDays(-5)
            });
            var postsDTO = new List<PostDTO>();
            var news = articlesResponse.Articles;
            foreach(var report in news)
            {
                PostDTO postDTO = new PostDTO(post_text: report.Title, dateposted: report.PublishedAt);
                postsDTO.Add(postDTO);
            }
            return postsDTO;
        }
    }
}
