using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.AddressRepository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
