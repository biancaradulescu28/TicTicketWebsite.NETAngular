using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.TicketUserRepository;
using TicTicket.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using TicTicket.Services.TicketService;
using TicTicket.Services.EventService;

namespace TicTicket.Services.TicketUserService
{
    public class TicketUserService : ITicketUserService
    {
        public ITicketUserRepository _ticketUserRepository;
        public ITicketService _ticketService;
        public IEventService _eventService;
        public IMapper _mapper;

        public TicketUserService(ITicketUserRepository ticketUserRepository, IMapper mapper, ITicketService ticketService, IEventService eventService)
        {
            _ticketUserRepository = ticketUserRepository;
            _mapper = mapper;
            _ticketService = ticketService;
            _eventService = eventService;
        }

        public async Task<List<TicketUser>> GetAll()
        {
            var ticketUsers = await _ticketUserRepository.GetAll();
            return ticketUsers;
        }


        public List<TicketUser> GetByTicketId(int ticketId)
        {
            var ticketUsers =  _ticketUserRepository.FindByTicketId(ticketId);
            return ticketUsers;

        }

        public List<TicketUser> GetByUserId(int userId)
        {
            var ticketUsers = _ticketUserRepository.FindByUserId(userId);
            return ticketUsers;

        }

        public async Task<TicketUser> GetByUserAndTicketId(int userId, int ticketId)
        {
            var ticketUsers = await _ticketUserRepository.FindByBothIds(userId, ticketId);
            return ticketUsers;

        }

        public async Task<TicketUser> AddTicketUser(int ticketId, int userId)
        {
            var newTicketUser = new TicketUserDto();
            newTicketUser.ticketId= ticketId;
            newTicketUser.userId= userId;
            var newDbTU = _mapper.Map<TicketUser>(newTicketUser);
            await _ticketUserRepository.CreateAsync(newDbTU);
            await _ticketUserRepository.SaveAsync();
            return newDbTU;

        }

        public async Task UpdateTicketUser(int ticketId, int userId)
        {
            var ToUpdate = await _ticketUserRepository.FindByBothIds(userId, ticketId);
            _ticketUserRepository.Update(ToUpdate);
            await _ticketUserRepository.SaveAsync();
        }

        public async Task DeleteTicketUser(int id)
        {
            var ToDelete = await _ticketUserRepository.FindByIdAsync(id);
            _ticketUserRepository.Delete(ToDelete);
            await _ticketUserRepository.SaveAsync();
        }

        public List<TicketUser> GetAllTicketsInUsersCart(int userId)
        {
            var tU = GetByUserId(userId);
            var ok = 0;
            var cartList = new List<TicketUser>();
            foreach (var t in tU)
            {
                if (t.status == Status.Cart)
                {
                    cartList.Add(t);
                    ok = 1;
                }
            }
            if (ok == 0)
            {
                return new List<TicketUser>();
            }
            return cartList;
        }

        public async Task<List<Ticket>> GetAllTicketsInCart(int userId)
        {
            var cartList = GetAllTicketsInUsersCart(userId);
            var ticketsList = new List<Ticket>();
            foreach (var t in cartList)
            {
                var ticket = await _ticketService.GetById(t.ticketId);
                ticketsList.Add(ticket);
            }
            return ticketsList;
        }

        public List<TicketUser> GetAllTicketsBoughtByUser(int userId)
        {
            var tU =  GetByUserId(userId);
            var bougthList = new List<TicketUser>();
            foreach (var t in tU)
            {
                if (t.status == Status.Bought)
                {
                    bougthList.Add(t);
                }
            }
            return bougthList;
        }

        public async Task<string> StatusBought(int ticketId, int userId)
        {
            var TUList = GetByTicketId(ticketId);
            foreach(var t in TUList)
            {
                t.status = Status.Bought;
                await UpdateTicketUser(t.ticketId,t.userId);
            }

            var ticket = await _ticketService.GetById(ticketId);
            var eventFound = await _eventService.GetById(ticket.EventId);
            if (eventFound == null)
            {
                return "no";
            }
            eventFound.NrTicketsAvailable = eventFound.NrTicketsAvailable - 1;
            await _eventService.UpdateEvent(eventFound.Id);

            return "Status changed to Bought!";

        }

        public async Task<string> StatusCart(int ticketId, int userId)
        { 
            var existingTU = await GetByUserAndTicketId(userId, ticketId);


            if (existingTU == null)
            {
                return "Not found!";
            }

            existingTU.status = Status.Cart;


            await UpdateTicketUser(ticketId, userId);
            return "Status changed to Cart!";

        }

   
    }
}
