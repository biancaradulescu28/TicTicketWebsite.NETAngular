using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Services.EventService;
using TicTicket.Services.TicketService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        public readonly ITicketService _ticketService;
        public readonly IEventService _eventService;

        public TicketsController(ITicketService ticketService, IEventService eventService)
        {
            _ticketService= ticketService;
            _eventService= eventService;
        }

        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok(await _ticketService.GetAll());
        }


        [HttpGet("{id}/GetTicketById")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            return Ok(await _ticketService.GetById(id));
        }


        [HttpGet("{eventName}/GetTicketsByEvent")]
        public async Task<List<Ticket>> GetTicketsByEvent(string eventName)
        {
            var foundEvent = _eventService.GetByName(eventName);
            return await _ticketService.GetByEvent(foundEvent.Id);
        }

        [HttpGet("{price, eventName}/GetTicketsByPrice")]
        public async Task<List<Ticket>> GetTicketsByPrice(double price, string eventName)
        {
            var ticketsTask = GetTicketsByEvent(eventName);
            var tickets = await ticketsTask;
            return _ticketService.GetByPrice(price, tickets);
        }


        [HttpPut("{id}/UpdateTicket")]
        public async Task<IActionResult> UpdateEvent(int id, TicketDto updatedTicket)
        {
            var existingTicket = await _ticketService.GetById(id);


            if (existingTicket == null)
            {
                return NotFound();
            }
            existingTicket.Seat = updatedTicket.Seat;
            existingTicket.Price = updatedTicket.Price;
            existingTicket.EventId = updatedTicket.EventId;

            await this._ticketService.UpdateTicket(id);
            return Ok();

        }


        [HttpPost("AddTicketToEvent")]
        public async Task<IActionResult> AddTicketToEvent(TicketDto newTicket, int eventId)
        {
            await this._ticketService.AddTicketToEvent(newTicket, eventId);
            return Ok();
        }



        [HttpDelete("{id}/DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await this._ticketService.DeleteTicket(id);
            return Ok();
        }


    }
}
