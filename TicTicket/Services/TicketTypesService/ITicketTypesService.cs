using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.TicketTypesService
{
    public interface ITicketTypesService
    {
        public Task<List<TicketTypes>> GetAll();
        public Task AddTicketType(TicketTypeDto newType);
        public Task DeleteType(int Id);
        public Task addTicketTypeToEvent(int eventId, int typeid);
        public List<TicketTypes> GetTypesForEvent(int eventId);
    }
}
