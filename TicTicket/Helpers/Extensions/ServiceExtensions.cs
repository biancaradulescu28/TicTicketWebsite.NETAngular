using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.Protocol.Core.Types;
using TicTicket.Repositories;
using TicTicket.Repositories.AddressRepository;
using TicTicket.Repositories.CartRepository;
using TicTicket.Repositories.EventRepository;
using TicTicket.Repositories.OrderRepository;
using TicTicket.Repositories.TicketRepository;
using TicTicket.Repositories.TicketTypesRepository;
using TicTicket.Repositories.TicketUserRepository;
using TicTicket.Services.AddressService;
using TicTicket.Services.CartService;
using TicTicket.Services.EventService;
using TicTicket.Services.OrderService;
using TicTicket.Services.TicketService;
using TicTicket.Services.TicketTypesService;
using TicTicket.Services.TicketUserService;
using TicTicket.Services.UserService;

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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketUserRepository, TicketUserRepository>();
            services.AddTransient<ITicketTypesRepository, TicketTypesRepository>();



            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITicketUserService, TicketUserService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ITicketTypesService, TicketTypesService>();



            return services;
        }

    }
}
