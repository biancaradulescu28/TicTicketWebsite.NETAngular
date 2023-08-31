using NuGet.DependencyResolver;
using TicTicket.Data;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User> FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}
