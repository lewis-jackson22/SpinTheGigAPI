using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SpinTheGig.Models;

namespace SpinTheGig.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Add DbSets here
        public DbSet<Episode> Episodes => Set<Episode>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Venue> Venues => Set<Venue>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Episode → Artist
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Artist)
                .WithMany(a => a.Episodes)
                .HasForeignKey(e => e.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            // Episode → Venue
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Episodes)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
