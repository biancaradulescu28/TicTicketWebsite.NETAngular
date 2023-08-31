using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketTypesRepository
{
    public interface ITicketTypesRepository: IGenericRepository<TicketTypes>
    {
        public Task<TicketTypes> FindByType(string type);
        public List<TicketTypes> FindByEventId(int eventId);
    }
}
