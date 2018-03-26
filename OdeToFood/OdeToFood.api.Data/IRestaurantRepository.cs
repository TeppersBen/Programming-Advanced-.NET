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
        Restaurant Add(Restaurant restaurant);
        Restaurant Remove(Restaurant restaurant);
        Restaurant GetById(int id);
        void Update(Restaurant restaurant);
        void Delete(int id);
    }
}
