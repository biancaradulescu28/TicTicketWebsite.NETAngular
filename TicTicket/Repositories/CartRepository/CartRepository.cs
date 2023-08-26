using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.CartRepository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DataContext context) : base(context)
        {
        }
    }
}
