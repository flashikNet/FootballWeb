using Dal.Player.Contexts;
using Dal.Player.Interfaces;
using Dal.Player.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dal
{
    public static class DalStartup
    {
        public static IServiceCollection TryAddDal(this IServiceCollection services)
        {
            services.TryAddScoped<IFootballRepository, FootballRepository>();
            return services;
        }
    }
}
