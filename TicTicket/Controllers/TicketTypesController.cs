using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Services.TicketTypesService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController : ControllerBase
    {
        public readonly ITicketTypesService _ticketTypesService;

        public TicketTypesController(ITicketTypesService ticketTypesService)
        {
            _ticketTypesService = ticketTypesService;
        }

        [HttpGet("GetAllTypes")]
        public async Task<IActionResult> GetAllTypes()
        {
            return Ok(await _ticketTypesService.GetAll());
        }


        [HttpPost("AddType")]
        public async Task<IActionResult> AddType(TicketTypeDto newType)
        {
            await this._ticketTypesService.AddTicketType(newType);
            return Ok();
        }



        [HttpDelete("{id}/DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await this._ticketTypesService.DeleteType(id);
            return Ok();
        }
    }
}
