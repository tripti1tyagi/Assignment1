using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Models
{
    public class CMSViewModel
    {
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }

        public int SelectedCategoryId { get; set; }
        public int SelectedSubcategoryId { get; set; } // ✅ Add this

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> SubcategoryList { get; set; }
    }
}