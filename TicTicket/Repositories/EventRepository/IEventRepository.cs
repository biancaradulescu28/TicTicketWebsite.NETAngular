using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.EventRepository
{
    public interface IEventRepository: IGenericRepository<Event>
    {
        public Event FindByName(string name);
        public Task<List<Event>> FindByAge(int age);
        public Task<List<Event>> FindByDate(DateTime date);
    }
}
