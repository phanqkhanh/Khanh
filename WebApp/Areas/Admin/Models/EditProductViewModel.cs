using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            GetNameType();
            GetNameFunction();
            GetNameCategories();
        }
        public EditProductViewModel(int id, string img, int? typeeID, int? categoriID, int? functionID, string title, string metaTitle)
        {
            ID = id;
            Img = img;
            TypeID = typeeID;
            CategoriesID = categoriID;
            FunctionID = functionID;
            Title = title;
            MetaTitle = metaTitle;
            GetNameType();
            GetNameFunction();
            GetNameCategories();
        }
        public int ID { get; set; }

        public string Img { get; set; }

        public int? TypeID { get; set; }
        public string TypeName { get; set; }

        public int? CategoriesID { get; set; }
        public string CategoriesName { get; set; }
        public int? FunctionID { get; set; }
        public string FunctionName { get; set; }

        public string Title { get; set; }

        public string MetaTitle { get; set; }

        public void GetNameType()
        {
            if (TypeID > 0)
            {
                using (MyDb db = new MyDb())
                {
                    this.TypeName = db.Typees.Find(this.TypeID) != null ?
                    db.Typees.Find(this.TypeID).Title : string.Empty;
                }
            }
        }
        public void GetNameFunction()
        {
            if (FunctionID > 0)
            {
                using (MyDb db = new MyDb())
                {
                    this.FunctionName= db.Functions.Find(this.FunctionID) != null ?
                    db.Functions.Find(this.FunctionID).Title : string.Empty;
                }
            }
        }
        public void GetNameCategories() 
        {
            if (CategoriesID > 0)
            {
                using (MyDb db = new MyDb())
                {
                    this.CategoriesName = db.Categories.Find(this.CategoriesID) != null ?
                    db.Categories.Find(this.CategoriesID).Title : string.Empty;
                }
            }
        }
    }
}