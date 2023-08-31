using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.TicketRepository;
using System.Net.Sockets;
using System.Data.Entity;
using System.Collections.Generic;
using TicTicket.Repositories.TicketTypesRepository;
using TicTicket.Services.TicketUserService;
using TicTicket.Models.Enums;
using TicTicket.Repositories.TicketUserRepository;

namespace TicTicket.Services.TicketService
{
    public class TicketService: ITicketService
    {
        public ITicketRepository _ticketRepository;
        public ITicketTypesRepository _ticketTypesRepository;
        public ITicketUserRepository _ticketUserRepository;
        public IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper, ITicketTypesRepository ticketTypesRepository, ITicketUserRepository ticketUserRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _ticketTypesRepository = ticketTypesRepository;
            _ticketUserRepository = ticketUserRepository;

        }

        public async Task<List<Ticket>> GetAll()
        {
            var tickets = await _ticketRepository.GetAll();
            return tickets;
        }


        public async Task<Ticket> GetById(int id)
        {
            var ticketById = await _ticketRepository.FindByIdAsync(id);
            return ticketById;

        }

        public List<Ticket> GetByEvent(int eventId)
        {
            var tickets =  _ticketRepository.FindByEvent(eventId);
            var ticketsEdit = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                var TU =  _ticketUserRepository.FindByTicketId(ticket.Id);
                if ((TU.Count != 0 && TU[0].status == 0) || TU.Count == 0)
                {
                    ticketsEdit.Add(ticket);
                }

            }
            return ticketsEdit;

        }

        public List<Ticket> GetByPrice(double price, List<Ticket> ticketsList)
        {
            var tickets = new List<Ticket>();
            foreach (var ticket in ticketsList)
            {
                if (ticket.Price == price)
                {
                    tickets.Add(ticket);
                }
            }

            return tickets;

        }

        public List<Ticket> GetByType(int typeId, List<Ticket> ticketsList)
        {
            var tickets = new List<Ticket>();
            foreach (var ticket in ticketsList)
            {
                if(ticket.TicketTypesId == typeId)
                {
                    tickets.Add(ticket);
                }
            }

            return tickets;

        }

        public async Task AddTypeToTicket(int ticketId, int typeid)
        {
            var ticketFound = await _ticketRepository.FindByIdAsync(ticketId);
            ticketFound.TicketTypesId = typeid;
            _ticketRepository.Update(ticketFound);
            await _ticketRepository.SaveAsync();
        }

        public async Task<Ticket> AddTicketToEvent(TicketDto newTicket, int eventId, double price)
        {
            var newDbTicket = _mapper.Map<Ticket>(newTicket);
            await _ticketRepository.CreateAsync(newDbTicket);
            await _ticketRepository.SaveAsync();
            var foundTicket = await _ticketRepository.FindByIdAsync(newDbTicket.Id);
            if (foundTicket == null) {
                return null;
            }
            foundTicket.EventId = eventId;
            foundTicket.Price = price;
            _ticketRepository.Update(foundTicket);
            await _ticketRepository.SaveAsync();
            return foundTicket;
        }

        public async Task UpdateTicket(int Id)
        {
            var ticketToUpdate = await _ticketRepository.FindByIdAsync(Id);
            _ticketRepository.Update(ticketToUpdate);
            await _ticketRepository.SaveAsync();
        }

        public async Task DeleteTicket(int Id)
        {
            var ticketToDelete = await _ticketRepository.FindByIdAsync(Id);
            _ticketRepository.Delete(ticketToDelete);
            await _ticketRepository.SaveAsync();
        }

    }
}
