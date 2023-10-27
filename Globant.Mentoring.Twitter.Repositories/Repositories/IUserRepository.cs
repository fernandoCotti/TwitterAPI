using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;

namespace Globant.Mentoring.Twitter.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUser(int userid);
        public Task<IEnumerable<User>> CreateUser(CreateUserDTO user);
        public Task<IEnumerable<User>> UpdateUser(int User_id, CreateUserDTO user);
        public Task<IEnumerable<User>> DeleteUser(int User_id);
        
    }
}
