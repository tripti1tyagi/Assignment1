using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Models
{
    public class CategorySubcategoryViewModel
    {
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public List<Subcategories> Subcategories { get; set; } = new List<Subcategories>();
    }
}