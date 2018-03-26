using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var apiProxy = new ApiProxy("http://localhost:51153/");

            ViewBag.Restaurant = await apiProxy.GetCourseRestaurantAsync(1);

            return View();
        }
    }
}
