using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using School.Business;

namespace School.api.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            var apiProxy = new ApiProxy("http://localhost:60116");
            ViewBag.Department = await apiProxy.GetCourseDepartmentAsync(1);

            return View();
        }
    }
}
