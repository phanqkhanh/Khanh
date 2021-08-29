using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models
{
    public class CreateProductViewModel
    {
        public string ID { get; set; }
        public string TypeName { get; set; }
        public string CategoriesName { get; set; }
        public string FunctionName { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public HttpPostedFileWrapper[] ImgDetails { get; set; }
    }
}