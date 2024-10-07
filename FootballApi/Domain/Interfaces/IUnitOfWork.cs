using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Player> Players { get; }
        public IRepository<Team> Teams { get; }
        public void Commit();
        public Task CommitAsync();
    }
}
