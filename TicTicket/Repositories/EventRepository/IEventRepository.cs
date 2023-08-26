using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.EventRepository
{
    public interface IEventRepository: IGenericRepository<Event>
    {
    }
}
