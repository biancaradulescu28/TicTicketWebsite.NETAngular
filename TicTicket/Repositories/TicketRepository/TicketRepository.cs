using System.Data.Entity;
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

        public List<Ticket> FindByEvent(int eventId)
        {
            return  _table.Where(x => x.EventId == eventId).ToList();
        }

        public async Task<List<Ticket>> FindByPrice(double price)
        {
            return await _table.Where(x => x.Price == price).ToListAsync();
        }

        public async Task<List<Ticket>> FindByType(int typeId)
        {
            return await _table.Where(x => x.TicketTypesId == typeId).ToListAsync();
        }

    }
}
