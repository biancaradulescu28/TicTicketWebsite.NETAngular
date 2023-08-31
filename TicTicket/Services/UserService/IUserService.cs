using Microsoft.AspNetCore.Mvc;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> GetByEmail(string email);
        public Task Register(UserRegister newUser);
        public Task AddAdmin(UserRegister newUser);
        public Task<string> Login(UserLogin request);
        public Task UpdateUser(int Id);
        public Task DeleteUser(int Id);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}
