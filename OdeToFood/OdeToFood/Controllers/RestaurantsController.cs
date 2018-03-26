using OdeToFood.api.Data;
using OdeToFood.api.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdRestaurant = _restaurantRepository.Add(restaurant);
            var restaurantUrl = Url.Link("DefaultApi", new { controller = "Restaurants", id = createdRestaurant.Id });
            return Created(restaurantUrl, createdRestaurant);
        }

        public IHttpActionResult GetRestaurant(int id)
        {
            throw new NotImplementedException();
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

        public IHttpActionResult Put(int id, Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Delete(int id)
        {
            if (_restaurantRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _restaurantRepository.Delete(id);
            return Ok();
        }

        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51153/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string url = "api/restaurants/" + id;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Restaurant restaurant = await response.Content.ReadAsAsync<Restaurant>();
                    return View(restaurant);
                }
            }
            return View();
        }
    }
}