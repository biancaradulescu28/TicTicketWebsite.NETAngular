using System.Data.Entity;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketTypesRepository
{
    public class TicketTypesRepository : GenericRepository<TicketTypes>, ITicketTypesRepository
    {
        public TicketTypesRepository(DataContext context) : base(context)
        {
        }

        public async Task<TicketTypes> FindByType(string type)
        {
            return _table.FirstOrDefault(x => x.Type == type);
        }

        public List<TicketTypes> FindByEventId(int eventId)
        {
            return _table.Where(x => x.EventId == eventId).ToList();
        }
    }
}
