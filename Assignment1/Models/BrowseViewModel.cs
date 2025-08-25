using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class BrowseViewModel
    {
        public int SelectedCategoryId { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Subcategories> Subcategories { get; set; }
    }
}