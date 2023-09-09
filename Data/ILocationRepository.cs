using System.Collections.Generic;
using LocationService.Models;

namespace LocationService.Data
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationById(int id);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
    }
}
