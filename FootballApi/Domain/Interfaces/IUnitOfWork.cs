using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Player> Players { get; set; }
        public IRepository<Team> Teams { get; set; }
        public void Commit();
    }
}
