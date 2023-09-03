using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Models.Enums;
using TicTicket.Services.AddressService;
using TicTicket.Services.UserService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAll());
        }


        [HttpGet("{id}/GetUserById")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpGet("{email}/GetUserByEmail")]
        public User GetUsersByEmail(string email)
        {
            return _userService.GetByEmail(email);
        }


        [HttpPut("{id}/UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, UserRegister updatedUser)
        {
            var existingUser = await _userService.GetById(id);


            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Age = updatedUser.Age;
            _userService.CreatePasswordHash(updatedUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            existingUser.PasswordHash = passwordHash;
            existingUser.PasswordSalt = passwordSalt;

            await this._userService.UpdateUser(id);
            return Ok();

        }


        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> AddAdminUser(UserRegister newUser)
        {
            await this._userService.AddAdmin(newUser);
            return Ok();
        }


        [HttpDelete("{id}/DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await this._userService.DeleteUser(id);
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegister newUser)
        {
            await this._userService.Register(newUser);
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin request)
        {
            var res = _userService.Login(request);
            if (res == "User not found.")
            {
                return BadRequest("User not found.");
            }
            else if(res == "Wrong password.")
            {
                return BadRequest("Wrong password.");
            }
            return Ok();
        }


    }
}
