using AutoMapper;
using TicTicket.Models.DTOs;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.TicketUserRepository;
using TicTicket.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace TicTicket.Services.TicketUserService
{
    public class TicketUserService : ITicketUserService
    {
        public ITicketUserRepository _ticketUserRepository;
        public IMapper _mapper;

        public TicketUserService(ITicketUserRepository ticketUserRepository, IMapper mapper)
        {
            _ticketUserRepository = ticketUserRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketUser>> GetAll()
        {
            var ticketUsers = await _ticketUserRepository.GetAll();
            return ticketUsers;
        }


        public async Task<List<TicketUser>> GetByTicketId(int ticketId)
        {
            var ticketUsers = await _ticketUserRepository.FindByTicketId(ticketId);
            return ticketUsers;

        }

        public async Task<List<TicketUser>> GetByUserId(int userId)
        {
            var ticketUsers = await _ticketUserRepository.FindByUserId(userId);
            return ticketUsers;

        }

        public async Task<TicketUser> GetByUserAndTicketId(int userId, int ticketId)
        {
            var ticketUsers = await _ticketUserRepository.FindByBothIds(userId, ticketId);
            return ticketUsers;

        }

        public async Task AddTicketUser(TicketUserDto newTicketUser)
        {
            var newDbTU = _mapper.Map<TicketUser>(newTicketUser);
            await _ticketUserRepository.CreateAsync(newDbTU);
            await _ticketUserRepository.SaveAsync();
        }

        public async Task UpdateTicketUser(int ticketId, int userId)
        {
            var ToUpdate = await _ticketUserRepository.FindByBothIds(userId, ticketId);
            _ticketUserRepository.Update(ToUpdate);
            await _ticketUserRepository.SaveAsync();
        }

        public async Task DeleteTicketUser(int ticketId, int userId)
        {
            var ToDelete = await _ticketUserRepository.FindByBothIds(userId, ticketId);
            _ticketUserRepository.Delete(ToDelete);
            await _ticketUserRepository.SaveAsync();
        }

        public async Task<List<TicketUser>> GetAllTicketsInUsersCart(int userId)
        {
            var tU = await GetByUserId(userId);
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

        public async Task<List<TicketUser>> GetAllTicketsBoughtByUser(int userId)
        {
            var tU = await GetByUserId(userId);
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
            var existingTU = await GetByUserAndTicketId(userId, ticketId);


            if (existingTU == null)
            {
                return "Not found!";
            }

            existingTU.status = Status.Bought;

            await UpdateTicketUser(ticketId, userId);
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
