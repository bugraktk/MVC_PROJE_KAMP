using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            ViewBag.linq1 = c.Categories.Count();
            ViewBag.linq2 = c.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.linq3 = c.Writers.Count(x => x.WriterName.Contains("a"));
            var t = c.Categories.Count(x => x.CategoryStatus == true);
            var f = c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.linq4 = t - f;
            ViewBag.linq5 = c.Headings.Max(x => x.Category.CategoryName);


            return View();
        }
    }
}