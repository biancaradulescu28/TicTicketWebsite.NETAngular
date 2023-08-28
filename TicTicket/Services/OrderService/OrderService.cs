using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.OrderRepository;

namespace TicTicket.Services.OrderService
{
    public class OrderService : IOrderService
    {

        private IOrderRepository _orderRepository;
        public IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }


        public async Task<Order> GetById(int id)
        {
            var orderById = await _orderRepository.FindByIdAsync(id);
            return orderById;

        }

        public async Task<List<Order>> GetByUser(int userId)
        {
            var orders = await _orderRepository.FindByUser(userId);
            return orders;

        }

        public async Task AddOrder(OrderDto newOrder)
        {
            var newDbOrder = _mapper.Map<Order>(newOrder);
            await _orderRepository.CreateAsync(newDbOrder);
            await _orderRepository.SaveAsync();
        }

        public async Task UpdateOrder(int Id)
        {
            var orderToUpdate = await _orderRepository.FindByIdAsync(Id);
            _orderRepository.Update(orderToUpdate);
            await _orderRepository.SaveAsync();
        }

        public async Task DeleteOrder(int Id)
        {
            var orderToDelete = await _orderRepository.FindByIdAsync(Id);
            _orderRepository.Delete(orderToDelete);
            await _orderRepository.SaveAsync();
        }

    }
}
