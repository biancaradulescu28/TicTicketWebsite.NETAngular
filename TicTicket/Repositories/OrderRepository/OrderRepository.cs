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
    }
}
