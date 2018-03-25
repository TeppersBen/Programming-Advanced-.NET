using OdeToFood.api.Data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OdeToFood.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.Register<OdeToFoodDB>(() => new OdeToFoodDB(), Lifestyle.Scoped);
            container.Register<IRestaurantRepository, RestaurantDBRepository>(Lifestyle.Scoped);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}