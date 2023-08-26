using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.OrderRepository
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
    }
}
