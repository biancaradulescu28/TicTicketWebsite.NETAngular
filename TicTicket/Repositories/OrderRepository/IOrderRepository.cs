using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.OrderRepository
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        public Task<List<Order>> FindByUser(int userId);
    }
}
