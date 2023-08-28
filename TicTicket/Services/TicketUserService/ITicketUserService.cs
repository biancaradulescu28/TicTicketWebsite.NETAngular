using Microsoft.AspNetCore.Mvc;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.TicketUserService
{
    public interface ITicketUserService
    {
        public Task<List<TicketUser>> GetAll();
        public Task<List<TicketUser>> GetByTicketId(int ticketId);
        public Task<List<TicketUser>> GetByUserId(int userId);
        public Task<TicketUser> GetByUserAndTicketId(int userId, int ticketId);
        public Task AddTicketUser(TicketUserDto newTicketUser);
        public Task UpdateTicketUser(int ticketId, int userId);
        public Task DeleteTicketUser(int ticketId, int userId);
        public Task<List<TicketUser>> GetAllTicketsInUsersCart(int userId);
        public Task<List<TicketUser>> GetAllTicketsBoughtByUser(int userId);
        public Task<string> StatusBought(int ticketId, int userId);
        public Task<string> StatusCart(int ticketId, int userId);
    }
}
