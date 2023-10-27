using Dapper;
using Globant.Mentoring.Twitter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Globant.Mentoring.Twitter.Repositories;
using Globant.Mentoring.Twitter.DTOs;
using Globant.Mentoring.Twitter.Services;
using Globant.Mentoring.Twitter.Exceptions;

namespace Globant.Mentoring.Twitter.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("/by-id")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var userDTO = await _userService.GetUserByID(id);
            return Ok(userDTO);
        }

        [HttpPost("/create-user")]
        public async Task<IActionResult> UsersAfterNewUser(CreateUserDTO user)
        {
            if (user.Username == "")
                return BadRequest("Username can't be blank.");
            else if (user.Username.Length > 30)
                return BadRequest("Username must be of 30 characteres or less.");
            try
            {
                return Ok(await _userService.UsersAfterCreation(user));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("/update-user")]
        public async Task<IActionResult> UpdateUser(int User_id, CreateUserDTO user)
        {
            try
            {
                return Ok(await _userService.UsersAfterUpdate(User_id, user));
            }
            catch (UserNotFoundException unfEx)
            {
                throw new UserNotFoundException($"{User_id} not found {unfEx.Message}.");
            }
            
        }

        [HttpDelete("/delete-user")]
        public async Task<IActionResult> DeleteUser(int User_id)
        {
            var usersAfterDeletion = await _userService.UsersAfterDeletion(User_id);
            return Ok(usersAfterDeletion);
        }
    }
}
