using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.TicketTypesRepository;
using AutoMapper;

namespace TicTicket.Services.TicketTypesService
{
    public class TicketTypesService : ITicketTypesService
    {
        ITicketTypesRepository _ticketTypesRepository;
        IMapper _mapper;

        public TicketTypesService(ITicketTypesRepository ticketTypesRepository, IMapper mapper)
        {
            _ticketTypesRepository = ticketTypesRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketTypes>> GetAll()
        {
            var types = await _ticketTypesRepository.GetAll();
            return types;
        }

        public async Task AddTicketType(TicketTypeDto newType)
        {
            var newDbType = _mapper.Map<TicketTypes>(newType);
            await _ticketTypesRepository.CreateAsync(newDbType);
            await _ticketTypesRepository.SaveAsync();
        }

        public async Task<TicketTypes> GetById(int id)
        {
            var typeById = await _ticketTypesRepository.FindByIdAsync(id);
            return typeById;

        }


        public async Task DeleteType(int Id)
        {
            var typeToDelete = await _ticketTypesRepository.FindByIdAsync(Id);
            _ticketTypesRepository.Delete(typeToDelete);
            await _ticketTypesRepository.SaveAsync();
        }

        public async Task addTicketTypeToEvent(int eventId, int typeId)
        {
            var typeFound = await _ticketTypesRepository.FindByIdAsync(typeId);
            typeFound.EventId =eventId;
            _ticketTypesRepository.Update(typeFound);
        }

        public List<TicketTypes> GetTypesForEvent(int eventId)
        {
            var types = _ticketTypesRepository.FindByEventId(eventId);
            return types;
        }

    }
}
