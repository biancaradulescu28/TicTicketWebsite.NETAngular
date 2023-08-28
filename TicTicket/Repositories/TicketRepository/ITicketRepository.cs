using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketRepository
{
    public interface ITicketRepository: IGenericRepository<Ticket>
    {
        public Task<List<Ticket>> FindByEvent(int eventId);
        public Task<List<Ticket>> FindByPrice(double price);
    }
}
