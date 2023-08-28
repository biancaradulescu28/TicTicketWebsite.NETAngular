using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.OrderService
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAll();
        public Task<Order> GetById(int id);
        public Task<List<Order>> GetByUser(int userId);
        public Task AddOrder(OrderDto newOrder);
        public Task UpdateOrder(int Id);
        public Task DeleteOrder(int Id);
    }
}
