using LocationService.Data;
using LocationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _repository;

        public LocationsController(ILocationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/locations
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            return Ok(_repository.GetLocations());
        }

        // GET: api/locations/1
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocationById(int id)
        {
            var location = _repository.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/locations
        [HttpPost]
        public ActionResult<Location> AddLocation(Location location)
        {
            _repository.AddLocation(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        // PUT: api/locations/1
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            location.Id = id; // Set the Id of the location object to the id from the URL
            _repository.UpdateLocation(location);
            return NoContent();
        }


        // DELETE: api/locations/1
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            _repository.DeleteLocation(id);
            return NoContent();
        }
    }
}
