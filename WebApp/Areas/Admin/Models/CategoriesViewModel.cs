using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel(int id, string title, string metatitle, int? functionID)
        {
            ID = id;
            Title = title;
            MetaTitle = metatitle;
            FunctionID = functionID;
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public int? FunctionID { get; set; }
    }
}