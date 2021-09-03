using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ProductViewModels
    {
        public ProductViewModels(int id, string img, int? typeID, int? categoriesID, int? functionID, string title, string metaTitle)
        {
            ID = id;
            Img = img;
            TypeID = typeID;
            CategoriesID = categoriesID;
            FunctionID = functionID;
            Title = title;
            MetaTitle = metaTitle;
            GetTypeName();
        }
        public int ID { get; set; }
        public string Img { get; set; }
        public int? TypeID { get; set; }
        public string TypeName { get; set; }
        public int? CategoriesID { get; set; }
        public int? FunctionID { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public void GetTypeName()
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
    }
}