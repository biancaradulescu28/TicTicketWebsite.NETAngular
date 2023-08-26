using AutoMapper;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Repositories.AddressRepository;

namespace TicTicket.Services.AddressService
{
    public class AddressService: IAddressService
    {
        public IAddressRepository _addressRepository;
        public IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;

        }

        public async Task<List<Address>> GetAll()
        {
            var addresses = await _addressRepository.GetAll();
            return addresses;
        }


        public async Task<Address> GetById(int id)
        {
            var addressById = await _addressRepository.FindByIdAsync(id);
            return addressById;

            //return _addressRepository.FindById(id);
        }

        public async Task AddAddress(AddressDto newAddress)
        {
            var newDbAddress = _mapper.Map<Address>(newAddress);
            await _addressRepository.CreateAsync(newDbAddress);
            await _addressRepository.SaveAsync();
        }

        public async Task UpdateAddress(int Id)
        {
            var addressToUpdate = await _addressRepository.FindByIdAsync(Id);
            _addressRepository.Update(addressToUpdate);
            await _addressRepository.SaveAsync();
        }

        public async Task DeleteAddress(int Id)
        {
            var addressToDelete = await _addressRepository.FindByIdAsync(Id);
            _addressRepository.Delete(addressToDelete);
            await _addressRepository.SaveAsync();
        }
    }
}
