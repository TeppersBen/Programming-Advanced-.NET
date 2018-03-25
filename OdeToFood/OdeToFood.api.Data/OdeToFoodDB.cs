using OdeToFood.api.Data.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.api.Data
{
    public class OdeToFoodDB : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OdeToFoodDB, Migrations.Configuration>());
        }
    }
}
