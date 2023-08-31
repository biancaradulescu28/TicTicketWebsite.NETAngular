using Microsoft.AspNetCore.Mvc;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.TicketUserService
{
    public interface ITicketUserService
    {
        public Task<List<TicketUser>> GetAll();
        public List<TicketUser> GetByTicketId(int ticketId);
        public List<TicketUser> GetByUserId(int userId);
        public Task<TicketUser> GetByUserAndTicketId(int userId, int ticketId);
        public Task AddTicketUser(int ticketId, int userId);
        public Task UpdateTicketUser(int ticketId, int userId);
        public Task DeleteTicketUser(int id);
        public List<TicketUser> GetAllTicketsInUsersCart(int userId);
        public List<TicketUser> GetAllTicketsBoughtByUser(int userId);
        public Task<string> StatusBought(int ticketId, int userId);
        public Task<string> StatusCart(int ticketId, int userId);
        public Task<List<Ticket>> GetAllTicketsInCart(int userId);
    }
}
