using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    internal class UnitOfWork(FootballContext context,
        IRepository<Player> players,
        IRepository<Team> teams) : IUnitOfWork
    {
        public IRepository<Player> Players { get; } = players;
        public IRepository<Team> Teams { get; } = teams;

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
