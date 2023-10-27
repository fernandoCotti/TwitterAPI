using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Models;
using Globant.Mentoring.Twitter.Repositories;

namespace Globant.Mentoring.Twitter.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,
                    Date_Created = user.DateCreated
                });
            }
            return usersDTO;
        }

        public async Task<UserDTO> GetUserByID(int id)
        {
            var userDTO = new UserDTO();
            var user = await _userRepository.GetUser(id);
            userDTO.Date_Created = user.DateCreated;
            userDTO.Username = user.Username;
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> UsersAfterDeletion(int id)
        {
             await _userRepository.DeleteUser(id);
            var usersAfterDeletion = await _userRepository.GetAllUsers();
            var usersDTOs = new List<UserDTO>();
            foreach (var user in usersAfterDeletion)
            {
                usersDTOs.Add(new UserDTO
                {
                    Username = user.Username,
                    Date_Created = user.DateCreated
                });
            }
            return usersDTOs;
        }

        public async Task<IEnumerable<UserDTO>> UsersAfterCreation(CreateUserDTO newUser)
        {

            await _userRepository.CreateUser(newUser);
            var usersAfterCreation = await _userRepository.GetAllUsers();
            var usersDTO = new List<UserDTO>();
            foreach(var user in usersAfterCreation) 
            {
                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,
                    Date_Created = user.DateCreated
                });
            }
            return usersDTO;
        }

        public async Task<IEnumerable<UserDTO>> UsersAfterUpdate(int id, CreateUserDTO updatedUser)
        {
            await _userRepository.UpdateUser(id,updatedUser);
            var usersAfterUpdate = await _userRepository.GetAllUsers();
            var usersDTO = new List<UserDTO>();
            foreach(var user in usersAfterUpdate) 
            {
                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,
                    Date_Created= user.DateCreated
                });
            }
            return usersDTO;
        }
    }
}
