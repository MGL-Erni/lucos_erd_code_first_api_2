using Microsoft.EntityFrameworkCore;

namespace lucos_erd_code_first_api_2
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Opening> Openings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerW)
                .WithMany()
                .HasForeignKey(g => g.PlayerWId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerB)
                .WithMany()
                .HasForeignKey(g => g.PlayerBId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.OpeningPlayed)
                .WithMany()
                .HasForeignKey(g => g.OpeningPlayedId);
        }
    }
}