using School.Data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace School.api.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            // 1. Create new Simple Injector Container
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<ICourseRepository, CourseDBRepository>(Lifestyle.Scoped);
            container.Register<SchoolDB>(() => new SchoolDB(), Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}