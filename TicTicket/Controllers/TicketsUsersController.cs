using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Services.EventService;
using TicTicket.Services.TicketService;
using TicTicket.Services.TicketUserService;
using TicTicket.Models.Enums;
using System.Net.Sockets;
using TicTicket.Services.CartService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsUsersController : ControllerBase
    {
        public readonly ITicketUserService _ticketUserService;
        public readonly ICartService _cartService;
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;

        public TicketsUsersController(ITicketUserService ticketUserService, ICartService cartService, ITicketService ticketService, IEventService eventService)
        {
            _ticketUserService = ticketUserService;
            _cartService = cartService;
            _ticketService = ticketService;
            _eventService = eventService;
        }


        [HttpGet("GetAllTicketsUsers")]
        public async Task<IActionResult> GetAllTicketsUsers()
        {
            return Ok(await _ticketUserService.GetAll());
        }


        [HttpGet("{ticketId}/GetTicketUsersByTicketId")]
        public async Task<List<TicketUser>> GetTicketUsersByTicketId(int ticketId)
        {
            var tU =  _ticketUserService.GetByTicketId(ticketId);
            return tU;
        }

        [HttpGet("{userId}/GetTicketUsersByUserId")]
        public async Task<List<TicketUser>> GetTicketUsersByUserId(int userId)
        {
            var tU =  _ticketUserService.GetByUserId(userId);
            return tU;
        }

        [HttpGet("{userId}/GetAllTicketsBoughtByUser")]
        public async Task<List<TicketUser>> GetAllTicketsBoughtByUser(int userId)
        {
            var boughtList =  _ticketUserService.GetAllTicketsBoughtByUser(userId);
            return boughtList;
        }

        [HttpGet("{userId}/GetAllTicketsInUsersCart")]
        public async Task<List<TicketUser>> GetAllTicketsInUsersCart(int userId)
        {

            var cartList =  _ticketUserService.GetAllTicketsInUsersCart(userId);
            return cartList;
        }

        [HttpGet("{userId}/GetAllTicketsInCart")]
        public async Task<List<Ticket>> GetAllTicketsInCart(int userId)
        {

            var cartList = await _ticketUserService.GetAllTicketsInCart(userId);
            return cartList;
        }

        [HttpGet("{userId}/{ticketId}/GetTicketUsersByBothId")]
        public async Task<IActionResult> GetTicketUsersByBothId(int userid, int ticketId)
        {
            return Ok(await _ticketUserService.GetByUserAndTicketId(userid, ticketId));
        }


        [HttpPut("{userId}/{ticketId}/UpdateTicketUser")]
        public async Task<IActionResult> UpdateTicketUser(int ticketId, int userId, TicketUser updatedTU)
        {
            var existingTU = await _ticketUserService.GetByUserAndTicketId(userId, ticketId);


            if (existingTU == null)
            {
                return NotFound();
            }

            existingTU.ticketId = updatedTU.ticketId;
            existingTU.userId = updatedTU.userId;
            existingTU.status = updatedTU.status;


            await this._ticketUserService.UpdateTicketUser(ticketId,userId);
            return Ok();

        }

        [HttpPut("{userId}/{ticketId}/StatusBought")]
        public async Task<IActionResult> StatusBought(int ticketId, int userId)
        {
            await _ticketUserService.StatusBought(ticketId, userId);
            return Ok();

        }

        [HttpPut("{userId}/{ticketId}/StatusCart")]
        public async Task<IActionResult> StatusCart(int ticketId, int userId)
        {
            await _ticketUserService.StatusCart(ticketId, userId);
            return Ok();

        }



        [HttpPost("{userId}/{ticketId}/AddTicketUser")]
        public async Task<TicketUser> AddTicketUser(int ticketId, int userId)
        {
            var TU = await this._ticketUserService.AddTicketUser(ticketId, userId);
            await StatusCart(ticketId, userId);
            
            //update detaii cart cu noul ticket
            var existingCart = _cartService.GetByUser(userId);
            existingCart.UserId = userId;
            existingCart.Quantity = await _cartService.CalculateQuantity(userId);
            existingCart.Price = await _cartService.CalculatePrice(userId);
            await _cartService.UpdateCart(existingCart.Id);
            return TU;
        }



        [HttpDelete("{id}/DeleteTicketUser")]
        public async Task<IActionResult> DeleteTicketUser(int id)
        {
            await this._ticketUserService.DeleteTicketUser(id);
            return Ok();
        }
    }
}
