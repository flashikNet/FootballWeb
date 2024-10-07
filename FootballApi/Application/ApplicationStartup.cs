using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application
{
    public static class ApplicationStartup
    {
        public static IServiceCollection TryAddServices(this IServiceCollection services)
        {
            services.TryAddScoped<IPlayerService, PlayerService>();
            services.TryAddScoped<ITeamService, TeamService>();
            return services;
        }
    }
}
