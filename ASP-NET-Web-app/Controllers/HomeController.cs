using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Web_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new Data.AppDbContext())
            {
                Data.SeedData.EnsureSeed(db);
            }
            return View();
        }
    }
}