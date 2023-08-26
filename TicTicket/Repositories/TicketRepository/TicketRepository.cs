using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;
using TicTicket.Repositories.OrderRepository;

namespace TicTicket.Repositories.TicketRepository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(DataContext context) : base(context)
        {
        }
    }
}
