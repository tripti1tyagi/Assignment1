using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignment1.Models; // Namespace of your EF models

namespace Assignment1.Controllers
{
    public class BrowseController : Controller
    {
        private AdbEntities db = new AdbEntities(); // Your Entity Framework context

        // GET: Browse
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CategorySubcategoryViewModel
            {
                Categories = db.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                    .ToList(),
                Subcategories = new List<Subcategories>() // Initially empty
            };

            return View(model);
        }

        // POST: Browse
        [HttpPost]
        public ActionResult Index(int SelectedCategoryId)
        {
            var subcategories = db.CategorySubcategoryMappings
                .Where(m => m.CategoryId == SelectedCategoryId)
                .Select(m => m.Subcategories)
                .ToList();

            var model = new CategorySubcategoryViewModel
            {
                SelectedCategoryId = SelectedCategoryId,
                Categories = db.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                    .ToList(),
                Subcategories = subcategories
            };

            return View(model);
        }
    }
}
