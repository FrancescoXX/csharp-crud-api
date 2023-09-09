



using LocationService.Models;

namespace LocationService.Data
{
    public class DbLocationRepository : ILocationRepository
    {
        private readonly LocationDbContext _context;

        public DbLocationRepository(LocationDbContext context)
        {
            _context = context;
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Locations.FirstOrDefault(l => l.Id == id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

        public Location GetLocationById(int id)
        {
            var location = _context.Locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                throw new Exception("Location not found");
            }
            return location;
        }

        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }



    }
}
