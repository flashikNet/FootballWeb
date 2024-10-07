using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection TryAddInfrastructure(this IServiceCollection services)
        {
            services.TryAddScoped<FootballContext>();
            services.TryAddScoped<IRepository<Player>, PlayerRepository>();
            services.TryAddScoped<IRepository<Team>, TeamRepository>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
