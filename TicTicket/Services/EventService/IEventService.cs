using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.EventService
{
    public interface IEventService
    {
        public Task<List<Event>> GetAll();
        public Task<Event> GetById(int id);
        public Task AddEvent(EventDto newEvent);
        public Task UpdateEvent(int Id);
        public Task DeleteEvent(int Id);
        public Event GetByName(string name);
        public Task<List<Event>> GetByAge(int age);
        public Task<List<Event>> GetByDate(DateTime date);

    }
}
