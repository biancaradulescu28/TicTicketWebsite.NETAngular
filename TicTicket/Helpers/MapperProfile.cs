using AutoMapper;
using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<TicketTypeDto, TicketTypes>();
            CreateMap<TicketTypes, TicketTypeDto>();
            CreateMap<TicketUserDto, TicketUser>();
            CreateMap<TicketUser, TicketUserDto>();



        }
    }

}
