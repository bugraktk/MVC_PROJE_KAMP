﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidatonRules;
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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());   
        public ActionResult Index()
        {
            var result = cm.GetList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var catval = cm.GetById(id);
            return View(catval);
        }
        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            cm.CategoryUpdate(c);
            return RedirectToAction("Index");
        }
    }
}