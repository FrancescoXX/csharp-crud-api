using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LocationService.Models
{
    public class Location
    {

        public Location()
        {
            Name = string.Empty; // Initialize with an empty string
        }
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        public string Name { get; set; }

        // Latitude and Longitude are already of type double, so they will only accept number-related values.
        // If you want to further restrict their range, you can use the Range attribute.
        // For example, for Latitude, which ranges from -90 to 90:
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double Latitude { get; set; }

        // For Longitude, which ranges from -180 to 180:
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double Longitude { get; set; }
    }
}
