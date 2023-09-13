using AiicoRestaurantApi;
using AiicoRestaurantApi.Controllers;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;

namespace RestaurantTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var restaurantController = new RestaurantController();
            var restuarants =  new List<Restaurant>()
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
            
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}