using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Globant.Mentoring.Twitter.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAllUsers();
        public Task<UserDTO> GetUserByID(int id);
        public Task<IEnumerable<UserDTO>> UsersAfterDeletion(int id);
        public Task<IEnumerable<UserDTO>> UsersAfterCreation(CreateUserDTO newUser);
        public Task<IEnumerable<UserDTO>> UsersAfterUpdate(int id, CreateUserDTO updatedUser);
    }
}
