using TicTicket.Models;
using TicTicket.Models.DTOs;

namespace TicTicket.Services.AddressService
{
    public interface IAddressService
    {
        public Task<List<Address>> GetAll();
        public Task<Address> GetById(int id);
        public Task AddAddress(AddressDto newAddress);
        public Task UpdateAddress(int Id);
        public Task DeleteAddress(int Id);

    }
}
