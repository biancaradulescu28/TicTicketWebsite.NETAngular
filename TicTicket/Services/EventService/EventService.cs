using AutoMapper;
using NuGet.DependencyResolver;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.TicketTypesRepository;
using TicTicket.Services.TicketTypesService;

namespace TicTicket.Services.EventService
{
    public class EventService: IEventService
    {
        public IEventRepository _eventRepository;
        public ITicketTypesRepository _ticketTypesRepository;
        public ITicketTypesService _ticketTypesService;
        public IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper, ITicketTypesRepository ticketTypesRepository, ITicketTypesService ticketTypesService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _ticketTypesRepository = ticketTypesRepository;
            _ticketTypesService = ticketTypesService;

        }

        public async Task<List<Event>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            return events;
        }


        public async Task<Event> GetById(int id)
        {
            var eventById = await _eventRepository.FindByIdAsync(id);
            return eventById;

        }

        public Event GetByName(string name)
        {
            var eventByName = _eventRepository.FindByName(name);
            return eventByName;

        }

        public async Task<List<Event>> GetByAge(int age)
        {
            var events = await _eventRepository.FindByAge(age);
            return events;

        }

        public async Task<List<Event>> GetByDate(DateTime date)
        {
            var events = await _eventRepository.FindByDate(date);
            return events;

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
