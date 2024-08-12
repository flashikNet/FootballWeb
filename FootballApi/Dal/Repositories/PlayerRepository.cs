using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class PlayerRepository(FootballContext context) : IRepository<Player>
    {
        private readonly DbSet<Player> _players = context.Players;

        public void Create(Player item)
        {
            _players.Add(item);
        }

        public void Delete(uint id)
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

        public async Task<Player> GetAsync(uint id)
        {
            return await _players.FindAsync(id);
        }

        public void UpdateAsync(Player item)
        {
            var old =  _players.Find(item.Id);
            if (old is not null)
            {
                old.Name = item.Name;
                old.Surname = item.Surname;
                old.Sex = item.Sex;
                old.Team = item.Team;
                old.BirthDate = item.BirthDate;
            }
        }
    }
}
