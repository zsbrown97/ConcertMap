using Microsoft.EntityFrameworkCore;
using ConcertMap.Models;

namespace ConcertMap.Data
{
    public class ConcertMapContext : DbContext
    {
        public ConcertMapContext(DbContextOptions<ConcertMapContext> options) : base(options) { }
        
        public DbSet<Venue> Venues => Set<Venue>();

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