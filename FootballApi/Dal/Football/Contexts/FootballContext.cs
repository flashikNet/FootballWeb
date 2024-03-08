using Dal.Football.Models;
using Dal.Player.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Player.Contexts
{
    public class FootballContext : DbContext
    {
        public DbSet<TeamDal> Teams { get; set; } = null!;
        public DbSet<PlayerDal> Players { get; set; } = null!;
        public DbSet<CountryDal> Countries { get; set; } = null!;

        public DbSet<PlayerViewDal> PlayersView { get; set; }

        public FootballContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../DataBase/Football.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerViewDal>(p =>
            {
                p.HasNoKey();
                p.ToView("PlayersView");
            });
        }
    }
}
