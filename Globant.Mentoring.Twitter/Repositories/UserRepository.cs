using Dapper;
using Globant.Mentoring.Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Globant.Mentoring.Twitter.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace Globant.Mentoring.Twitter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<User> users = await SelectAllUsers(connection);
            return users;
        }

        private static async Task<IEnumerable<User>> SelectAllUsers(SqlConnection connection) //Lo agrego también a la interfaz?
        {
            return await connection.QueryAsync<User>("select * from [user]");
        }

        public async Task<User> GetUser(int userid)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryFirstAsync<User>("select * from [user] where user_id = @User_id",
                new { User_id = userid });
            return user;
        }
        public async Task<IEnumerable<User>> CreateUser(CreateUserDTO user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into [user] (Username, date_created, is_active, last_login_date) values (@username, current_timestamp, 1, current_timestamp) ", user);
            var createdUser = await SelectAllUsers(connection);
            return createdUser;
        }

        public async Task<IEnumerable<User>> UpdateUser(int User_id, CreateUserDTO user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update [user] set Username = @username where user_id = @User_id", user);
            var updatedUser = await SelectAllUsers(connection);
            return updatedUser;
        }

        public async Task<IEnumerable<User>> DeleteUser(int userid)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from [user] where user_id = @User_id", new { user_id = userid });
            var allUsers = await SelectAllUsers(connection);
            return allUsers;
        }

    }
}
