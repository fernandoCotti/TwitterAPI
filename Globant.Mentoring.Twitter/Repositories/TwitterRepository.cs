using Dapper;
using Globant.Mentoring.Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Repositories;

namespace Globant.Mentoring.Twitter.Controllers
{

    public class TwitterRepository : ITwitterRepository
    {
        private readonly IConfiguration _config;

        public TwitterRepository(IConfiguration config)
        {
            _config = config;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        
        //Return the hot topics.
        public async Task<IEnumerable<Post>> GetHotTopics()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var sql = @"select *
                        from post p
                        inner join post_tags pt on (p.post_id = pt.fk_post_id)
                        inner join tag t on (t.tag_id = pt.fk_tag_id)
                        " ;
            var posts = await connection.QueryAsync<Post, Tag, Post>(sql, (post, tag) =>
            {
                post.Tags.Add(tag);
                return post;
            }, splitOn: "tag_id");
            var result = posts.GroupBy(p => p.PostId).Select(g =>
            {
                var groupedPosts = g.First();
                groupedPosts.Tags = g.Select(p => p.Tags.Single()).ToList();
                return groupedPosts;
            });
            var topics = result.ToList();
            return topics;
        }

        //Return timeline (posts from their followed people and general news) given a user ID.
        public async Task<IEnumerable<Post>> ShowTimeline(int userId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var posts = await connection.QueryAsync<Post>(@"select * from post p 
                                                            inner join [user] u on (u.user_id = p.fk_user_id) 
                                                            inner join following_users fu on (fu.fk_id_followed = u.user_id) 
                                                            where fu.fk_id_follower = @ID",
                new {ID = userId});
            return posts;
        }


        //How many followers has a user.
        public async Task<int> GetFollowers(int userid)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var followers = await connection.QueryFirstAsync<int>("select count(*) from following_users where fk_id_followed = @User_id",
                new { User_id = userid });
            return followers;
        }
    }
}
