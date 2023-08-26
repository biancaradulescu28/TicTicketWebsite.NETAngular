using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.EventRepository
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }
    }
}
