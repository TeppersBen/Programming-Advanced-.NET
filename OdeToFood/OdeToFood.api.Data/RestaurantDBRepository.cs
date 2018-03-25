﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.api.Data.DomainClasses;

namespace OdeToFood.api.Data
{
    class RestaurantDBRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDB _context;

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return _context.Restaurants.FirstOrDefault(c => c.Id == restaurant.Id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant Remove(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
