using OdeToFood.api.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.api.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodDB>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFoodDB context)
        {
            context.Restaurants.AddOrUpdate(d => d.Name,
                new Restaurant { Name = "MCDonalds",
                                 Id = 0,
                                 Country = "Belgium",
                                 City = "Houthalen"
                });

            context.SaveChanges();
        }

    }
}
