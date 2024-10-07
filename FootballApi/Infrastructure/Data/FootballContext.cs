using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FootballContext : DbContext
    {
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;

        public FootballContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../DataBase/Football.db");
        }
    }
}
