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
        public Cart FindByUser(int userId)
        {
            return _table.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
