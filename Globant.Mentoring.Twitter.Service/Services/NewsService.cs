using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.DTOs;
using Microsoft.Extensions.Configuration;

namespace Globant.Mentoring.Twitter.Services
{
    public class NewsService : INewsService
    {
        private readonly string? _apiKey;

        // The NewsAPI key comes from configuration ("NewsApi:ApiKey"), e.g. via
        // `dotnet user-secrets` or the NewsApi__ApiKey environment variable.
        public NewsService(IConfiguration config)
        {
            _apiKey = config["NewsApi:ApiKey"];
        }

        public List<PostDTO> GetNewsAsPostDTOs()
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new InvalidOperationException("NewsApi:ApiKey is not configured.");

            var newsApiClient = new NewsApiClient(_apiKey);
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
