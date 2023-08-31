using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketRepository
{
    public interface ITicketRepository: IGenericRepository<Ticket>
    {
        public List<Ticket> FindByEvent(int eventId);
        public Task<List<Ticket>> FindByPrice(double price);
        public Task<List<Ticket>> FindByType(int typeId);
    }
}
