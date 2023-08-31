using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.TicketUserRepository
{
    public interface ITicketUserRepository : IGenericRepository<TicketUser>
    {
        public List<TicketUser> FindByTicketId(int ticketId);
        public List<TicketUser> FindByUserId(int userId);
        public Task<TicketUser> FindByTicketIdInList(int ticketId, List<TicketUser> list);
        public Task<TicketUser> FindByBothIds(int userId, int ticketId);
    }
}
