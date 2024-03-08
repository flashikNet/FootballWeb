using Logic.Player.Interface;
using Logic.Player.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic
{
    public static class LogicStartup
    {
        public static IServiceCollection TryAddLogic(this IServiceCollection services)
        {
            services.TryAddScoped<IFootballLogicManager, FootballLogicManager>();
            return services;
        }
    }
}
