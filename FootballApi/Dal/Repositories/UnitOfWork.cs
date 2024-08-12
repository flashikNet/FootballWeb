using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UnitOfWork(FootballContext db) : IUnitOfWork
    {
        public IRepository<Player> Players { get; set; } = new PlayerRepository(db);
        public IRepository<Team> Teams { get; set; } = new TeamRepository(db);

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
