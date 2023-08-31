using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;
using System.Data.Entity;
using System.Net.Sockets;

namespace TicTicket.Repositories.TicketUserRepository
{
    public class TicketUserRepository : GenericRepository<TicketUser>, ITicketUserRepository
    {
        public TicketUserRepository(DataContext context) : base(context)
        {
        }
        public List<TicketUser> FindByTicketId(int ticketId)
        {
            return _table.Where(x => x.ticketId == ticketId).ToList();
        }

        public async Task<TicketUser> FindByTicketIdInList(int ticketId, List<TicketUser>list)
        {
            foreach (var ticketUser in list)
            {
                if (ticketUser.ticketId == ticketId)
                {
                    return ticketUser;
                }
            }
            return null;
            
        }

        public List<TicketUser> FindByUserId(int userId)
        {
            return _table.Where(x => x.userId == userId).ToList();
        }

        public async Task<TicketUser> FindByBothIds(int userId, int ticketId)
        {
            var ticketUsers = FindByUserId(userId);
            var tU = FindByTicketIdInList(ticketId, ticketUsers);
            return await tU;

        }
    }
}
