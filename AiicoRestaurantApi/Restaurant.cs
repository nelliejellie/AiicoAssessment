using System.ComponentModel.DataAnnotations;

namespace AiicoRestaurantApi
{


    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public int distance { get; set; }

    }
}