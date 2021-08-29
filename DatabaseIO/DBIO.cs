using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class DBIO
    {
        MyDb mydb = new MyDb();
        public List<Product> GetProducts()
        {
            return mydb.Products.ToList();
        }
        public List<Product> GetProductsF(string name)
        {
            var fun = mydb.Functions.Where(f => f.Title == name).FirstOrDefault();
            return mydb.Products.Where(p => p.FunctionID == fun.id).ToList();
        }
        public List<Product> GetProductsC(string name)
        {
            var fun = mydb.Categories.Where(f => f.Title == name).FirstOrDefault();
            return mydb.Products.Where(p => p.CategoriesID == fun.ID).ToList();
        }
        public List<Category> GetCt(int id)
        {
            return mydb.Categories
                .Where(c => c.FunctionID == id).ToList();
            //return mydb.Categories.Where(m => m.FunctionID == id).ToList();
        }
        public List<Typee> GetT(string name)
        {
            var cate = mydb.Categories.Where(c => c.Title == name).FirstOrDefault();
            return mydb.Typees
                .Where(t => t.CategoriesID == cate.ID).ToList();
        }
        public List<Product> GetProductsCT(string nameC, string nameT) 
        {
            var cate = mydb.Categories.Where(c => c.Title == nameC).FirstOrDefault();
            var typee = mydb.Typees.Where(c => c.Title == nameT && c.CategoriesID ==cate.ID).FirstOrDefault();
            return mydb.Products
                .Where(p => p.TypeID == typee.ID).ToList();
        }
        public void Create(string img, int typeID, int categoriesID, int functionID, string title, string metaTitle)
        {
            Product product = new Product();
            product.Img = img;
            product.TypeID = typeID;
            product.CategoriesID = categoriesID;
            product.FunctionID = functionID;
            product.Title = title;
            product.MetaTitle = metaTitle;
            mydb.Products.Add(product);
            Save();
        }
        public int GetFId(string name)
        {
            var i = mydb.Functions.Where(a => a.Title == name).FirstOrDefault();
            return i.id;
        }
        public int GetTId(string name)
        {
            var i = mydb.Typees.Where(a => a.Title == name).FirstOrDefault();
            return i.ID;
        }
        public int GetCId(string name)
        {
            var i = mydb.Categories.Where(a => a.Title == name).FirstOrDefault();
            return i.ID;
        }
        public void DeleteProduct(int id)
        {
            var product = mydb.Products.Where(p => p.ID == id).FirstOrDefault();
            var productDetail = mydb.ProductDetails.Where(p => p.ProductId == id).ToList();
            mydb.ProductDetails.RemoveRange(productDetail);
            mydb.Products.Remove(product);
            Save();
        }
        public List<string> GetAllImg(int id)
        {
            List<string> ls = new List<string>();
            var imgTitle = mydb.Products.Where(p => p.ID == id).FirstOrDefault();
            var imgDetail = mydb.ProductDetails.Where(p => p.ProductId == id).ToList();
            ls.Add(imgTitle.Img);
            if(imgDetail != null)
            {
                foreach (var item in imgDetail)
                {
                    ls.Add(item.Img);
                }
            }
            return ls;
        }
        public List<Product> GetEdit(int id)
        {
            return mydb.Products.Where(p => p.ID == id).ToList();
        }
        public List<ProductDetail> GetEditImgDetail(int id)
        {
            return mydb.ProductDetails.Where(p => p.ProductId == id).ToList();
        }
        public void DeleteImgDetail(int id)
        {
            
        }
        public void EditProduct(int id ,string img, int typeID, int categoriesID, int functionID, string title, string metaTitle)
        {
            
        }
        public void Save()
        {
            mydb.SaveChanges();
        }
    }
}
