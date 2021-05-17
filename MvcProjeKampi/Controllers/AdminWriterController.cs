using BusinessLayer.Concrete;
using BusinessLayer.ValidatonRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminWriterController : Controller
    {
        WriterManager wr = new WriterManager(new EFWriterDal());
        public ActionResult Index(int page=1)
        {
            //var getres = wr.GetList();
            var getres = wr.GetList().ToPagedList(page,6);
            return View(getres);
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer w)
        {
            WriterValidator val = new WriterValidator();
            ValidationResult results = val.Validate(w); 
            if (results.IsValid)
            {             
                wr.WriterAdd(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var e in results.Errors)
                {
                    ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult WriterDelete(int id)
        {
            var del = wr.GetById(id);
            wr.WriterDelete(del);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult WriterUpdate(int id)
        {
            var up = wr.GetById(id);
            return View(up);
        }
        [HttpPost]
        public ActionResult WriterUpdate(Writer w)
        {
            wr.WriterUpdate(w);
            return RedirectToAction("Index");
        }
    }
}