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


        [HttpGet("{eventId}/GetTicketsByEvent")]
        public List<Ticket> GetTicketsByEvent(int eventId)
        {
            return _ticketService.GetByEvent(eventId);
        }

        [HttpGet("{price, eventName}/GetTicketsByPrice")]
        public async Task<List<Ticket>> GetTicketsByPrice(double price, int eventId)
        {
            var ticketsTask = GetTicketsByEvent(eventId);
            var tickets = ticketsTask;
            return _ticketService.GetByPrice(price, tickets);
        }

        [HttpGet("{price, eventName}/GetTicketsByType")]
        public async Task<List<Ticket>> GetTicketsByType(int typeId, int eventId)
        {
            var ticketsTask = GetTicketsByEvent(eventId);
            var tickets = ticketsTask;
            return _ticketService.GetByType(typeId, tickets);
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

        [HttpPut("{id}/AddTypeToTicket")]
        public async Task<IActionResult> AddTypeToTicket(int id, int typeId)
        {
            await _ticketService.AddTypeToTicket(id, typeId);


            return Ok();

        }


        [HttpPost("AddTicketToEvent")]
        public async Task<IActionResult> AddTicketToEvent(TicketDto newTicket, int eventId, double price)
        {
            await this._ticketService.AddTicketToEvent(newTicket, eventId, price);
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
