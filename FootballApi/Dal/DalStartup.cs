using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dal
{
    public static class DalStartup
    {
        public static IServiceCollection TryAddDal(this IServiceCollection services)
        {
            services.TryAddScoped<FootballContext, FootballContext>();
            return services;
        }
    }
}
