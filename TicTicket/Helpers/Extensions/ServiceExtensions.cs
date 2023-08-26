using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.Protocol.Core.Types;
using TicTicket.Repositories.AddressRepository;
using TicTicket.Repositories.CartRepository;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.OrderRepository;
using TicTicket.Repositories.TicketRepository;
using TicTicket.Services.AddressService;
using TicTicket.Services.EventService;

namespace TicTicket.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IAddressService, AddressService>();



            return services;
        }
    }
}
