using System.Threading.Tasks;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.TicketService
{
    public interface ITicketService
    {
        public Task<List<Ticket>> GetAll();
        public Task<Ticket> GetById(int id);
        public List<Ticket> GetByEvent(int eventId);
        public List<Ticket> GetByPrice(double price, List<Ticket> ticketsList);
        public List<Ticket> GetByType(int typeId, List<Ticket> ticketsList);
        public Task<Ticket> AddTicketToEvent(TicketDto newTicket, int eventId, double price);
        public Task UpdateTicket(int Id);
        public Task DeleteTicket(int Id);
        public Task AddTypeToTicket(int ticketId, int typeid);
    }
}
