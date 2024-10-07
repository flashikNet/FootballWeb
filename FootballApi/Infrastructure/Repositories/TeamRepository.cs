using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class TeamRepository(FootballContext context) : IRepository<Team>
    {
        private readonly DbSet<Team> _team = context.Teams;

        public async Task CreateAsync(Team item)
        {
            await _team.AddAsync(item);
        }

        public void Delete(Guid id)
        {
            var team = _team.Find(id);
            if (team is not null)
            {
                _team.Remove(team);
            }
        }

        public IQueryable<Team> GetAll()
        {
            return _team;
        }

        public async Task<Team?> GetAsync(Guid id)
        {
            return await _team.FindAsync(id);
        }

        public async Task UpdateAsync(Team item)
        {
            var old = await _team.FindAsync(item.Id);
            if (old is not null)
            {
                old.Name = item.Name;
            }
        }
    }
}
