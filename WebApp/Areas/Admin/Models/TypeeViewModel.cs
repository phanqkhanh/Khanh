using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models
{
    public class TypeeViewModel
    {
        public TypeeViewModel(int id, int? categoriesID, string title, string metatitle) 
        {
            ID = id;
            CategoriesID = categoriesID;
            Title = title;
            MetaTitle = metatitle;
        }
        public int ID { get; set; }
        public int? CategoriesID { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
    }
}