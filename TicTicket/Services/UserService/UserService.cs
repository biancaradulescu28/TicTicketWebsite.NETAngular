using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories;
using TicTicket.Repositories.AddressRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TicTicket.Models.Enums;
using NuGet.DependencyResolver;
using TicTicket.Repositories.CartRepository;

namespace TicTicket.Services.UserService
{
    public class UserService: IUserService
    {
        public IUserRepository _userRepository;
        public ICartRepository _cartRepository;
        public IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, ICartRepository cartRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _cartRepository= cartRepository;

        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users;
        }


        public async Task<User> GetById(int id)
        {
            var userById = await _userRepository.FindByIdAsync(id);
            return userById;

        }

        public async Task<User> GetByEmail(string email)
        {
            var userByEmail = await _userRepository.FindByEmail(email);
            return userByEmail;

        }


        public async Task Register(UserRegister newUser)
        {
            CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newDbUser = new User();
            newDbUser.FirstName = newUser.FirstName;
            newDbUser.LastName = newUser.LastName;
            newDbUser.Email = newUser.Email;
            newDbUser.Age = newUser.Age;
            newDbUser.PasswordHash = passwordHash;
            newDbUser.PasswordSalt = passwordSalt;
            newDbUser.Role = Role.User;

            await _userRepository.CreateAsync(newDbUser);
            await _userRepository.SaveAsync();

            var cart = new CartDto();
            cart.UserId = newDbUser.Id;

            var newDbCart = _mapper.Map<Cart>(cart);
            newDbCart.User = newDbUser;
            await _cartRepository.CreateAsync(newDbCart);
            await _cartRepository.SaveAsync();

        }

        public async Task AddAdmin(UserRegister newUser)
        {
            CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newDbUser = new User();
            newDbUser.FirstName = newUser.FirstName;
            newDbUser.LastName = newUser.LastName;
            newDbUser.Email = newUser.Email;
            newDbUser.Age = newUser.Age;
            newDbUser.PasswordHash = passwordHash;
            newDbUser.PasswordSalt = passwordSalt;
            newDbUser.Role = Role.Admin;

            await _userRepository.CreateAsync(newDbUser);
            await _userRepository.SaveAsync();

        }

        public async Task<string> Login(UserLogin request)
        {
            var foundUser = await _userRepository.FindByEmail(request.Email);
            if (foundUser == null)
            {
                return "User not found.";//TODO: Toast
            }


            if (!VerifyPasswordHash(request.Password, foundUser.PasswordHash, foundUser.PasswordSalt))
            {
                return "Wrong password.";//TODO: Toast
            }
            var token = CreateToken(foundUser);
            return "good";
        }

        public async Task UpdateUser(int Id)
        {
            var userToUpdate = await _userRepository.FindByIdAsync(Id);
            _userRepository.Update(userToUpdate);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUser(int Id)
        {
            var userToDelete = await _userRepository.FindByIdAsync(Id);
            _userRepository.Delete(userToDelete);
            await _userRepository.SaveAsync();
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
