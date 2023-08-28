using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.TicketRepository;
using System.Net.Sockets;
using System.Data.Entity;
using System.Collections.Generic;

namespace TicTicket.Services.TicketService
{
    public class TicketService: ITicketService
    {
        public ITicketRepository _ticketRepository;
        public IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;

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

        public async Task<List<Ticket>> GetByEvent(int eventId)
        {
            var tickets = await _ticketRepository.FindByEvent(eventId);
            return tickets;

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

        public async Task AddTicketToEvent(TicketDto newTicket, int eventId)
        {
            var newDbTicket = _mapper.Map<Ticket>(newTicket);
            newDbTicket.EventId= eventId;
            await _ticketRepository.CreateAsync(newDbTicket);
            await _ticketRepository.SaveAsync();
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
