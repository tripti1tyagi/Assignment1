using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class CMSController : Controller
    {
        private AdbEntities db = new AdbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CMSViewModel
            {
                CategoryList = db.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                }).ToList(),

                SubcategoryList = db.Subcategories.Select(s => new SelectListItem
                {
                    Value = s.SubcategoryId.ToString(),
                    Text = s.SubcategoryName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCategory(string CategoryName)
        {
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                db.Categories.Add(new Categories { CategoryName = CategoryName });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateSubcategory(string SubcategoryName)
        {
            if (!string.IsNullOrWhiteSpace(SubcategoryName))
            {
                db.Subcategories.Add(new Subcategories { SubcategoryName = SubcategoryName });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult MapCategorySubcategory(int SelectedCategoryId, int SelectedSubcategoryId)
        {
            var exists = db.CategorySubcategoryMappings.Any(m => m.CategoryId == SelectedCategoryId && m.SubcategoryId == SelectedSubcategoryId);
            if (!exists)
            {
                db.CategorySubcategoryMappings.Add(new CategorySubcategoryMappings
                {
                    CategoryId = SelectedCategoryId,
                    SubcategoryId = SelectedSubcategoryId
                });
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}