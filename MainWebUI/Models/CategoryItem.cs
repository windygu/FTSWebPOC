using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTS.MainWebUI.Models
{
    public class CategoryItem
    {
        public string CategoryName { get; set; }
        public List<SubCategoryItem> SubCategories { get; set; }
    }
}