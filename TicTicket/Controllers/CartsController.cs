using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Services.CartService;
using TicTicket.Services.TicketService;
using System.Data.Entity.ModelConfiguration.Configuration;
using TicTicket.Services.TicketUserService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public readonly ICartService _cartService;
        public readonly ITicketUserService _ticketUserService;
        public readonly ITicketService _ticketService;

        public CartsController(ICartService cartService, ITicketUserService ticketUserService, ITicketService ticketService)
        {
            _cartService = cartService;
            _ticketUserService= ticketUserService;
            _ticketService = ticketService;
        }

        [HttpGet("GetAllCarts")]
        public async Task<IActionResult> GetAllCarts()
        {
            return Ok(await _cartService.GetAll());
        }


        [HttpGet("{id}/GetCartById")]
        public async Task<IActionResult> GetCartById(int id)
        {
            return Ok(await _cartService.GetById(id));
        }

        [HttpGet("{userId}/GetCartByUser")]
        public Cart GetCartByUser(int userId)
        {
            return _cartService.GetByUser(userId);
        }


        [HttpPut("{id}/UpdateCart")]
        public async Task<IActionResult> UpdateCart(int id, CartDto updatedCart)
        {
            var existingCart = await _cartService.GetById(id);


            if (existingCart == null)
            {
                return NotFound();
            }

            existingCart.Quantity = updatedCart.Quantity;
            existingCart.Price = updatedCart.Price;
            existingCart.UserId = updatedCart.UserId;

            await this._cartService.UpdateCart(id);
            return Ok();

        }

        [HttpGet("{userId}/GetAllTicketsInCart")]
        public async Task<List<Ticket>> GetAllTicketsInCart(int userId)
        {
            var tickets = await _cartService.GetAllTicketsInCart(userId);
            return tickets;
        }



    }
}
