using System.Threading.Tasks;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.TicketService
{
    public interface ITicketService
    {
        public Task<List<Ticket>> GetAll();
        public Task<Ticket> GetById(int id);
        public Task<List<Ticket>> GetByEvent(int eventId);
        public List<Ticket> GetByPrice(double price, List<Ticket> ticketsList);
        public Task AddTicketToEvent(TicketDto newTicket, int eventId);
        public Task UpdateTicket(int Id);
        public Task DeleteTicket(int Id);
    }
}
