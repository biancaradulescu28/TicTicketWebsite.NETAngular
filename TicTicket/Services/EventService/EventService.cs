using AutoMapper;
using NuGet.DependencyResolver;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Repositories.EventRepository;

namespace TicTicket.Services.EventService
{
    public class EventService: IEventService
    {
        public IEventRepository _eventRepository;
        public IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;

        }

        public async Task<List<EventDto>> GetAllEvents()
        {
            var events = await _eventRepository.GetAll();
            List<EventDto> result = _mapper.Map<List<EventDto>>(events);
            return result;
        }

        public Event GetById(int id)
        {
            return _eventRepository.FindById(id);
        }

        public async Task AddEvent(EventDto newEvent)
        {
            var newDbEvent = _mapper.Map<Event>(newEvent);
            await _eventRepository.CreateAsync(newDbEvent);
            await _eventRepository.SaveAsync();
        }

        public async Task UpdateEvent(int Id)
        {
            var eventToUpdate = await _eventRepository.FindByIdAsync(Id);
            _eventRepository.Update(eventToUpdate);
            await _eventRepository.SaveAsync();
        }

        public async Task DeleteEvent(int Id)
        {
            var eventToDelete = await _eventRepository.FindByIdAsync(Id);
            _eventRepository.Delete(eventToDelete);
            await _eventRepository.SaveAsync();
        }



    }
}
