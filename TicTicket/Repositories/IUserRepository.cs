using NuGet.DependencyResolver;
using TicTicket.Models;
using TicTicket.Repositories.GenericRepository;

namespace TicTicket.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> FindByEmail(string email);
    }
}
