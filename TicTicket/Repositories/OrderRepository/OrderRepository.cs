using System.Data.Entity;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Order>> FindByUser(int userId)
        {
            return await _table.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
