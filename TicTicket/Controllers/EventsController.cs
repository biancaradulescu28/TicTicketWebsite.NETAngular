using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Services.EventService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await _eventService.GetAll());
        }


        [HttpGet("{id}/GetEventById")]
        public async Task<IActionResult> GetEventById(int id)
        {
            return Ok(await _eventService.GetById(id));
        }

        [HttpGet("{name}/GetEventByName")]
        public Event GetEventByName(string name)
        {
            return _eventService.GetByName(name);
        }

        [HttpGet("{age}/GetEventsByAge")]
        public async Task<List<Event>> GetEventsByAge(int age)
        {
            return await _eventService.GetByAge(age);
        }

        [HttpGet("{date}/GetEventsByDate")]
        public async Task<List<Event>> GetEventsByDate(DateTime date)
        {
            return await _eventService.GetByDate(date);
        }


        [HttpPut("{id}/UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(int id, EventDto updatedEvent)
        {
            var existingEvent = await _eventService.GetById(id);


            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.StartDate = updatedEvent.StartDate;
            existingEvent.EndDate = updatedEvent.EndDate;
            existingEvent.NrTickets = updatedEvent.NrTickets;
            existingEvent.NrTicketsAvailable = updatedEvent.NrTicketsAvailable;
            existingEvent.AgeLimit = updatedEvent.AgeLimit;
            existingEvent.AddressId = existingEvent.AddressId;

            await this._eventService.UpdateEvent(id);
            return Ok();

        }


        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(EventDto newEvent)
        {
            await this._eventService.AddEvent(newEvent);
            return Ok();
        }


        
        [HttpDelete("{id}/DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await this._eventService.DeleteEvent(id);
            return Ok();
        }
    }
}
