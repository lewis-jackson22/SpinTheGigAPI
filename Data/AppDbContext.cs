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
        public DbSet<Beverage> Beverages => Set<Beverage>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Episode primary key
            modelBuilder.Entity<Episode>()
                .HasKey(e => e.Number);

            // Money precision
            modelBuilder.Entity<Episode>()
                .Property(e => e.TicketPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Episode>()
                .Property(e => e.PreGigBeveragePrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Episode>()
                .Property(e => e.MidGigBeveragePrice)
                .HasPrecision(8, 2);

            // Episode → Main Artist
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.MainArtist)
                .WithMany(a => a.MainEpisodes)
                .HasForeignKey(e => e.MainArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            // Episode → Supporting Artist
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.SupportingArtist)
                .WithMany(a => a.SupportingEpisodes)
                .HasForeignKey(e => e.SupportingArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            // Episode → Venue
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.MainVenueEpisodes)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Episode → Pre Gig Pub
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.PreGigPub)
                .WithMany(v => v.PreGigPubEpisodes)
                .HasForeignKey(e => e.PreGigPubId)
                .OnDelete(DeleteBehavior.Restrict);

            // Episode → Pre Gig Beverage
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.PreGigBeverage)
                .WithMany(v => v.PreGigEpisodes)
                .HasForeignKey(e => e.PreGigBeverageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Episode → Mid Gig Beverage
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.MidGigBeverage)
                .WithMany(v => v.MidGigEpisodes)
                .HasForeignKey(e => e.MidGigBeverageId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
