using Dapper;
using Globant.Mentoring.Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Globant.Mentoring.Twitter.DTOs;


namespace Globant.Mentoring.Twitter.Repositories
{

    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration _config;

        public PostRepository(IConfiguration config)
        {
            _config = config;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task<IEnumerable<Post>> GetPostsFromUser(int userid)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var posts = await connection.QueryAsync<Post>(@"select p.post_id,p.post_text, p.date_posted from post p
                                                           where fk_user_id = @User_id",
                new { User_id = userid });
            return posts;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<Post> users = await SelectAllPosts(connection);
            return users;
        }

        private static async Task<IEnumerable<Post>> SelectAllPosts(SqlConnection connection)
        {
            return await connection.QueryAsync<Post>("select * from post");
        }

        public async Task<IEnumerable<Post>> DeletePost(int postid)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from post where post_id = @Post_id", new { Post_id = postid });
            var allPosts = await SelectAllPosts(connection);
            return allPosts;
        }
    }
}
