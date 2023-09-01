using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Services.OrderService;
using TicTicket.Services.TicketUserService;
using TicTicket.Services.CartService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderService _orderService;
        public readonly ICartService _cartService;
        public readonly ITicketUserService _ticketUserService;

        public OrdersController(IOrderService orderService, ICartService cartService, ITicketUserService ticketUserService)
        {
            _orderService = orderService;
            _cartService= cartService;
            _ticketUserService = ticketUserService;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAll());
        }


        [HttpGet("{id}/GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }


        [HttpGet("{age}/GetOrdersByUser")]
        public async Task<List<Order>> GetOrdersByUser(int userId)
        {
            return await _orderService.GetByUser(userId);
        }


        [HttpPut("{id}/UpdateOrder")]
        public async Task<IActionResult> UpdateEvent(int id, OrderDto updatedOrder)
        {
            var existingOrder = await _orderService.GetById(id);


            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Price = updatedOrder.Price;
            existingOrder.Quantity = updatedOrder.Quantity;
            existingOrder.UserId = updatedOrder.UserId;
            

            await this._orderService.UpdateOrder(id);
            return Ok();

        }


        [HttpPost("{userId}/MakeOrder")]
        public async Task<IActionResult> MakeOrder(int userId)
        {
            var newOrder = new OrderDto();
            newOrder.UserId = userId;
            var tickets = await _cartService.GetAllTicketsInCart(userId);
            var price = await _cartService.CalculatePrice(userId);
            var quantity = await _cartService.CalculateQuantity(userId);
            foreach (var ticket in tickets)
            {
                await _ticketUserService.StatusBought(ticket.Id, userId);
            }
            newOrder.Tickets = tickets;
            newOrder.Quantity = quantity;
            newOrder.Price = price;

            await this._orderService.AddOrder(newOrder);

            var existingCart = _cartService.GetByUser(userId);
            existingCart.UserId = userId;
            existingCart.Quantity = 0;
            existingCart.Price= 0;
            await _cartService.UpdateCart(existingCart.Id);

            return Ok();
        }



        [HttpDelete("{id}/DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await this._orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
