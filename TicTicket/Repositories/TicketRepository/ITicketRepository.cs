using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketRepository
{
    public interface ITicketRepository: IGenericRepository<Ticket>
    {
    }
}
