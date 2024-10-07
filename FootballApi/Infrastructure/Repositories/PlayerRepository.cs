using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class PlayerRepository(FootballContext context) : IRepository<Player>
    {
        private readonly DbSet<Player> _players = context.Players;

        public async Task CreateAsync(Player item)
        {
            await _players.AddAsync(item);
        }

        public void Delete(Guid id)
        {
            var player = _players.Find(id);
            if (player is not null)
            {
                _players.Remove(player);
            }
        }

        public IQueryable<Player> GetAll()
        {
            return _players;
        }

        public async Task<Player?> GetAsync(Guid id)
        {
            return await _players.FindAsync(id);
        }

        public async Task UpdateAsync(Player item)
        {
            var old = await _players.FindAsync(item.Id);
            if (old is not null)
            {
                old.Name = item.Name;
                old.Surname = item.Surname;
                old.Sex = item.Sex;
                old.Team = item.Team;
                old.BirthDate = item.BirthDate;
                old.Country = item.Country;
            }
        }
    }
}
