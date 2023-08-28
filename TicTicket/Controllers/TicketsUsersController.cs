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

        public TicketsUsersController(ITicketUserService ticketUserService, ICartService cartService)
        {
            _ticketUserService = ticketUserService;
            _cartService = cartService;
           
        }

        [HttpGet("GetAllTicketsUsers")]
        public async Task<IActionResult> GetAllTicketsUsers()
        {
            return Ok(await _ticketUserService.GetAll());
        }


        [HttpGet("{ticketId}/GetTicketUsersByTicketId")]
        public async Task<List<TicketUser>> GetTicketUsersByTicketId(int ticketId)
        {
            var tU = await _ticketUserService.GetByTicketId(ticketId);
            return tU;
        }

        [HttpGet("{userId}/GetTicketUsersByUserId")]
        public async Task<List<TicketUser>> GetTicketUsersByUserId(int userId)
        {
            var tU = await _ticketUserService.GetByUserId(userId);
            return tU;
        }

        [HttpGet("{userId}/GetAllTicketsBoughtByUser")]
        public async Task<List<TicketUser>> GetAllTicketsBoughtByUser(int userId)
        {
            var boughtList = await _ticketUserService.GetAllTicketsBoughtByUser(userId);
            return boughtList;
        }

        [HttpGet("{userId}/GetAllTicketsInUsersCart")]
        public async Task<List<TicketUser>> GetAllTicketsInUsersCart(int userId)
        {

            var cartList = await _ticketUserService.GetAllTicketsInUsersCart(userId);
            return cartList;
        }

        [HttpGet("{userId, ticketId}/GetTicketUsersByBothId")]
        public async Task<IActionResult> GetTicketUsersByBothId(int userid, int ticketId)
        {
            return Ok(await _ticketUserService.GetByUserAndTicketId(userid, ticketId));
        }


        [HttpPut("{ticketId, userId}/UpdateTicketUser")]
        public async Task<IActionResult> UpdateTicketUser(int ticketId, int userId, TicketUser updatedTU)
        {
            var existingTU = await _ticketUserService.GetByUserAndTicketId(userId, ticketId);


            if (existingTU == null)
            {
                return NotFound();
            }

            existingTU.TicketsId = updatedTU.TicketsId;
            existingTU.UsersId = updatedTU.UsersId;
            existingTU.status = updatedTU.status;


            await this._ticketUserService.UpdateTicketUser(ticketId,userId);
            return Ok();

        }

        [HttpPut("{ticketId, userId}/StatusBought")]
        public async Task<string> StatusBought(int ticketId, int userId)
        {
            return await _ticketUserService.StatusBought(ticketId, userId);

        }

        [HttpPut("{ticketId, userId}/StatusCart")]
        public async Task<string> StatusCart(int ticketId, int userId)
        {
            return await _ticketUserService.StatusCart(ticketId, userId);

        }



        [HttpPost("AddTicketUser")]
        public async Task<IActionResult> AddTicketUser(TicketUserDto TU)
        {
            await this._ticketUserService.AddTicketUser(TU);
            StatusCart(TU.TicketsId, TU.UsersId);
            
            //update detaii cart cu noul ticket
            var existingCart = _cartService.GetByUser(TU.UsersId);
            existingCart.UserId = TU.UsersId;
            existingCart.Quantity = await _cartService.CalculateQuantity(TU.UsersId);
            existingCart.Price = await _cartService.CalculatePrice(TU.UsersId);
            _cartService.UpdateCart(existingCart.Id);
            return Ok();
        }



        [HttpDelete("{id}/DeleteTicketUser")]
        public async Task<IActionResult> DeleteTicketUser(int ticketId, int userId)
        {
            await this._ticketUserService.DeleteTicketUser(ticketId, userId);
            return Ok();
        }
    }
}
