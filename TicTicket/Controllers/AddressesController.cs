using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Models.DTOs;
using TicTicket.Services.AddressService;
using TicTicket.Services.EventService;

namespace TicTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        public readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            return Ok(await _addressService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            return Ok(await _addressService.GetById(id));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressDto updatedAddress)
        {
            var existingAddress = await _addressService.GetById(id);


            if (existingAddress == null)
            {
                return NotFound();
            }

            existingAddress.Country = updatedAddress.Country;
            existingAddress.City = updatedAddress.City;
            existingAddress.Street = updatedAddress.Street;
            existingAddress.Number = updatedAddress.Number;

            await this._addressService.UpdateAddress(id);
            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressDto newAddress)
        {
            await this._addressService.AddAddress(newAddress);
            return Ok();
        }


        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await this._addressService.DeleteAddress(id);
            return Ok();
        }

       
    }
}
