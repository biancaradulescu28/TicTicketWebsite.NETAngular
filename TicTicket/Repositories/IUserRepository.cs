using NuGet.DependencyResolver;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public User FindByEmail(string email);
    }
}
