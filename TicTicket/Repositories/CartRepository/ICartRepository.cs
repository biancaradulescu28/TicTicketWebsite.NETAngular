using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.CartRepository
{
    public interface ICartRepository: IGenericRepository<Cart>
    {
        public Cart FindByUser(int userId);
    }
}
