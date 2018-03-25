using OdeToFood.api.Data;
using OdeToFood.api.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Controllers
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantRepository _restaurantRepository;
        
        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        // GET: api/Restaurants
        public IEnumerable<Restaurant> Get()
        {
            return _restaurantRepository.GetAll();
        }

        // POST: api/restaurants
        public IHttpActionResult Post([FromBody] Restaurant restaurant)
        {
            var createdRestaurant = _restaurantRepository.Add(restaurant);
            var restaurantUrl = Url.Link("DefaultApi", new { controller = "Restaurants", id = createdRestaurant.Id });
            return Created(restaurantUrl, createdRestaurant);
        }

        //api/restaurants/5
        public IHttpActionResult GetById(int id)
        {
            if (id == 1)
            {
                var restaurant = new Restaurant
                {
                    Id = 1,
                    Name = "Unknown",
                    City = "Unknown",
                    Country = "Unknown"
                };
                return Ok(restaurant);
            }
            return NotFound();
        }
    }
}