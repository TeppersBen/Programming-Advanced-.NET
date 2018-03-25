using OdeToFood.api.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests.Builders
{
    public class RestaurantBuilder
    {
        public static int ID { get; set; }

        private Restaurant _restaurant;

        public RestaurantBuilder()
        {
            _restaurant = new Restaurant
            {
                Id = ID++,
                Name = Guid.NewGuid().ToString(),
                City = Guid.NewGuid().ToString(),
                Country = Guid.NewGuid().ToString()
            };
        }

        public Restaurant Build()
        {
            return _restaurant;
        }

    }
}
