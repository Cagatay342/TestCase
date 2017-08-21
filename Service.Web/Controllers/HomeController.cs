using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            var x = s.GetData();
            return View(x);
        }
    }
}