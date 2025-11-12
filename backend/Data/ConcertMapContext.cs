using Microsoft.EntityFrameworkCore;
using ConcertMap.Models;

namespace ConcertMap.Data
{
    public class ConcertMapContext : DbContext
    {
        public ConcertMapContext(DbContextOptions<ConcertMapContext> options) : base(options) { }

        public DbSet<Band> Bands => Set<Band>();
        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Festival> Festivals => Set<Festival>();
        public DbSet<FestivalBand> FestivalBands => Set<FestivalBand>();
        public DbSet<Headliner> Headliners => Set<Headliner>();
        public DbSet<Opener> Openers => Set<Opener>();
        public DbSet<Venue> Venues => Set<Venue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalBand>()
                .HasKey(b => new { b.FestivalId, b.BandId });
            
            modelBuilder.Entity<FestivalBand>()
                .HasOne(b => b.Festival)
                .WithMany(f => f.FestivalBands)
                .HasForeignKey(b => b.FestivalId);
            
            modelBuilder.Entity<FestivalBand>()
                .HasOne(b => b.Band)
                .WithMany()
                .HasForeignKey(b => b.BandId);
            
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
            
            modelBuilder.Entity<Opener>()
                .HasKey(o => new { o.ConcertId, o.BandId});
            
            modelBuilder.Entity<Opener>()
                .HasOne(o => o.Concert)
                .WithMany(c => c.Openers)
                .HasForeignKey(o => o.ConcertId);
            
            //modelBuilder.Entity<Headliner>()
            //    .HasOne(o => o.Band)
            //    .WithMany()
            //    .HasForeignKey(o => o.BandId);
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