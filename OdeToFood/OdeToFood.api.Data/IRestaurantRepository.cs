using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.api.Data.DomainClasses;

namespace OdeToFood.api.Data
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        void Add(Restaurant restaurant);
        void Remove(Restaurant restaurant);
    }
}
