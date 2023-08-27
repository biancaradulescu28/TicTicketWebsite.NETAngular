using System.Data.Entity;
using System.Linq;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories.EventRepository
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }

        public Event FindByName(string name)
        {
            return _table.FirstOrDefault(x => x.Name == name);
        }

        public async Task<List<Event>> FindByAge(int age)
        {
            return await _table.Where(x => x.AgeLimit == age).ToListAsync();
        }

        public async Task<List<Event>> FindByDate(DateTime date)
        {
            return await _table.Where(x => x.StartDate <= date && (x.EndDate >= date || x.EndDate == null)).ToListAsync();
        }
    }
}
