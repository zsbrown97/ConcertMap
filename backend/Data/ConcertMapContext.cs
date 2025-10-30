using Microsoft.EntityFrameworkCore;
using ConcertMap.Models;

namespace ConcertMap.Data
{
    public class ConcertMapContext : DbContext
    {
        public ConcertMapContext(DbContextOptions<ConcertMapContext> options) : base(options) { }

        public DbSet<Band> Bands => Set<Band>();
        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Headliner> Headliners => Set<Headliner>();
        public DbSet<Venue> Venues => Set<Venue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Headliner>()
                .HasKey(h => new { h.ConcertId, h.BandId});
            
            modelBuilder.Entity<Headliner>()
                .HasOne(h => h.Concert)
                .WithMany(c => c.Headliners)
                .HasForeignKey(h => h.ConcertId);
            
            modelBuilder.Entity<Headliner>()
                .HasOne(h => h.Band)
                .WithMany()
                .HasForeignKey(h => h.BandId);
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Scorecard>()
            //    .HasKey(sc => new { sc.GameId, sc.PlayerId });
        }
        */
    }
}