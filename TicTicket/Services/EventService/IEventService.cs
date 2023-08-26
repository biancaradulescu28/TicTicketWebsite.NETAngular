using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.EventService
{
    public interface IEventService
    {
        public Task<List<EventDto>> GetAllEvents();
        public Event GetById(int id);
        public Task AddEvent(EventDto newEvent);
        public Task UpdateEvent(int Id);
        public Task DeleteEvent(int Id);
    }
}
