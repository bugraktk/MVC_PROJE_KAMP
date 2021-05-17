using BusinessLayer.Concrete;
using BusinessLayer.ValidatonRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminHeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        Context c = new Context();
        public ActionResult Index()
        {
            var result = hm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> dgr1 = (from i in c.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.CategoryId.ToString()
                                        }).ToList();
            List<SelectListItem> dgr2 = (from w in c.Writers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = w.WriterName+" "+w.WriterSurname,
                                             Value = w.WriterId.ToString()
                                         }).ToList();
            ViewBag.dgr1 = dgr1;
            ViewBag.dgr2 = dgr2;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading heading)
        {
            HeadingValidator val = new HeadingValidator();
            ValidationResult result = val.Validate(heading);
            if(result.IsValid)
            {
                hm.HeadingAdd(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var h in result.Errors)
                {
                    ModelState.AddModelError(h.PropertyName, h.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult HeadingDelete(int id)
        {
            var del = hm.GetById(id);
            hm.HeadingDelete(del);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HeadingUpdate(int id)
        {
            var upd = hm.GetById(id);
            return View(upd);
        }
        [HttpPost]
        public ActionResult HeadingUpdate(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
    }
}