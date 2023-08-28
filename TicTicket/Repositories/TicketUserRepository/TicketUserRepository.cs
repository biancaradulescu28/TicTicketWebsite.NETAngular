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
        public async Task<List<TicketUser>> FindByTicketId(int ticketId)
        {
            return await _table.Where(x => x.TicketsId == ticketId).ToListAsync();
        }

        public async Task<TicketUser> FindByTicketIdInList(int ticketId, List<TicketUser>list)
        {
            foreach (var ticketUser in list)
            {
                if (ticketUser.TicketsId == ticketId)
                {
                    return ticketUser;
                }
            }
            return null;
            
        }

        public async Task<List<TicketUser>> FindByUserId(int userId)
        {
            return await _table.Where(x => x.UsersId == userId).ToListAsync();
        }

        public async Task<TicketUser> FindByBothIds(int userId, int ticketId)
        {
            var ticketUsers = await FindByUserId(userId);
            var tU = FindByTicketIdInList(ticketId, ticketUsers);
            return await tU;

        }
    }
}
