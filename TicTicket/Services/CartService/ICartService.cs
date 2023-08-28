using TicTicket.Models;

namespace TicTicket.Services.CartService
{
    public interface ICartService
    {
        public Task<List<Cart>> GetAll();
        public Task<Cart> GetById(int id);
        public Cart GetByUser(int userId);
        public Task UpdateCart(int Id);
        public Task DeleteCart(int Id);
        public Task<List<Ticket>> GetAllTicketsInCart(int userId);
        public Task<double> CalculatePrice(int userId);
        public Task<int> CalculateQuantity(int userId);

    }
}
