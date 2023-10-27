using NewsAPI;
using NewsAPI.Models;
using Globant.Mentoring.Twitter.DTOs;
using NewsAPI.Constants;

namespace Globant.Mentoring.Twitter.Services
{
    public interface INewsService
    {
        public List<PostDTO> GetNewsAsPostDTOs();
    }
}
