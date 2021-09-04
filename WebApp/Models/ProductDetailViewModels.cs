using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ProductDetailViewModels
    {
        public ProductDetailViewModels(int id, string title, string metaTitle, string img, int? typeid) 
        {
            ID = id;
            Title = title;
            MetaTitle = metaTitle;
            Img = img;
            TypeID = typeid;
            GetTypeName();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Img { get; set; }
        public int? TypeID { get; set; }
        public string TypeName { get; set; }
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