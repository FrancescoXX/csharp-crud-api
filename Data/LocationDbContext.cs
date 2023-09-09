using Microsoft.EntityFrameworkCore;

namespace LocationService.Models
{
    public class LocationDbContext : DbContext
    {
        public DbSet<Location> ?Locations { get; set; }

        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: If you want to rename the Locations table to "TblLocations"
            modelBuilder.Entity<Location>().ToTable("locations");

            // Add other configurations here if needed
        }
    }
}
