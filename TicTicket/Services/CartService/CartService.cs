using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.CartRepository;
using TicTicket.Services.TicketUserService;
using TicTicket.Services.TicketService;

namespace TicTicket.Services.CartService
{
    public class CartService : ICartService
    {
        public ICartRepository _cartRepository;
        public ITicketUserService _ticketUserService;
        public ITicketService _ticketService;

        public CartService(ICartRepository cartRepository, ITicketUserService ticketUserService, ITicketService ticketService)
        {
            _cartRepository = cartRepository;
            _ticketUserService = ticketUserService;
            _ticketService = ticketService;
        }

        public async Task<List<Cart>> GetAll()
        {
            var carts = await _cartRepository.GetAll();
            return carts;
        }

        public async Task<Cart> GetById(int id)
        {
            var cartById = await _cartRepository.FindByIdAsync(id);
            return cartById;

        }

        public Cart GetByUser(int userId)
        {
            return _cartRepository.FindByUser(userId);

        }

        public async Task UpdateCart(int Id)
        {
            var cartToUpdate = await _cartRepository.FindByIdAsync(Id);
            _cartRepository.Update(cartToUpdate);
            await _cartRepository.SaveAsync();
        }

        public async Task DeleteCart(int Id)
        {
            var cartToDelete = await _cartRepository.FindByIdAsync(Id);
            _cartRepository.Delete(cartToDelete);
            await _cartRepository.SaveAsync();
        }

        public async Task<List<Ticket>> GetAllTicketsInCart(int userId)
        {
            var tU = await _ticketUserService.GetAllTicketsInUsersCart(userId);
            var tickets = new List<Ticket>();
            foreach (var t in tU)
            {
                var ticket = await _ticketService.GetById(t.TicketsId);
                tickets.Add(ticket);
            }
            return tickets;
        }

        public async Task<double> CalculatePrice(int userId)
        {
            var ticketsTask = GetAllTicketsInCart(userId);
            var tickets = await ticketsTask;
            double price = 0;
            foreach (var ticket in tickets)
            {
                price += ticket.Price;
            }

            return price;
        }

        public async Task<int> CalculateQuantity(int userId)
        {
            var ticketsTask = GetAllTicketsInCart(userId);
            var tickets = await ticketsTask;
            return tickets.Count();
        }

    }
}
