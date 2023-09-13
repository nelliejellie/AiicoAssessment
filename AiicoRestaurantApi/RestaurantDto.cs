using System.ComponentModel.DataAnnotations;

namespace AiicoRestaurantApi
{
    public class RestaurantDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public int Longitude { get; set; }
        [Required]
        public int Latitude { get; set; }
        [Required]
        public int distance { get; set; }
    }
}
