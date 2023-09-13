using Microsoft.AspNetCore.Mvc;

namespace AiicoRestaurantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<Restaurant> restaurants = new List<Restaurant>()
        {
           new Restaurant
            {
                Id = 1,
                Name = "Restaurant A",
                Address = "123 Main Street",
                Longitude = 10,
                Latitude = 20,
                distance = 5,
                City = "new york"
            },
            new Restaurant
            {
                Id = 2,
                Name = "Restaurant B",
                Address = "456 Elm Street",
                Longitude = 15,
                Latitude = 25,
                distance = 8,
                City = "Lagos"
            },
            new Restaurant
            {
                Id = 3,
                Name = "Restaurant C",
                Address = "789 Oak Street",
                Longitude = 20,
                Latitude = 30,
                distance = 12,
                City = "Oyo"
            }
        };

        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllRestaurants")]
        public IActionResult  GetAllRestaurants()
        {
            return Ok(new
            {
                status = "successful",
                data = restaurants
            });
        }

        [HttpPost("AddRestaurants")]
        public IActionResult AddRestaurant([FromBody]RestaurantDto restaurantDto)
        {
            Random random = new Random();
            var newRestaurant = new Restaurant
            {
                Id = random.Next(1, 101),
                Name = restaurantDto.Name,
                Address = restaurantDto.Address,
                City = restaurantDto.City,
                Latitude=restaurantDto.Latitude,
                Longitude=restaurantDto.Longitude,
                distance=restaurantDto.distance
            };

            restaurants.Add(newRestaurant);

            return CreatedAtAction(nameof(GetAllRestaurants), restaurants);

        }

        [HttpGet("GetRestaurantById/{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            var rest = restaurants.FirstOrDefault(x => x.Id == id);
            if (rest == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                status = "successful",
                data = rest
            });

        }

        [HttpGet("GetRestaurantByAddress")]
        public IActionResult GetRestaurantByAddress( [FromQuery]string city, [FromQuery] int lat, [FromQuery]int longi)
        {
            var rest = restaurants.Where(x => x.City == city)
                .Where(x => x.Latitude == lat)
                .Where(x => x.Longitude == longi).ToList();
            if (rest == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                status = "successful",
                data = rest
            });

        }

        [HttpPut("UpdateRestaurant/{id}")]
        public IActionResult UpdateRestaurant(int id,[FromBody] RestaurantDto restaurantDto)
        {
            Random random = new Random();
            var rest = restaurants.FirstOrDefault(x => x.Id == id);
            if (rest == null)
            {
                return NotFound();
            }
            var newRestaurant = new Restaurant
            {
                Name = restaurantDto.Name,
                Address = restaurantDto.Address,
                City = restaurantDto.City,
                Latitude = restaurantDto.Latitude,
                Longitude = restaurantDto.Longitude,
                distance = restaurantDto.distance
            };

            rest = newRestaurant;

            return Ok(new
            {
                status = "successful",
                data = rest
            });

        }

        [HttpDelete("DeleteRestaurant")]
        public IActionResult DelateRestaurant(int id)
        {
            var rest = restaurants.FirstOrDefault(x => x.Id == id);
            restaurants.Remove(rest);

            return NoContent();
        }
    }
}