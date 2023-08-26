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

        }
    }

}
