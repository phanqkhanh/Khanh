using DatabaseIO;
using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Admin.Models;
using System.IO;
namespace WebApp.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DBIO db = new DBIO();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListProducts(string nameF)
        {
            try
            {
                var ls = new List<ProductViewModel>();
                if (nameF == "Chọn")
                {
                    db.GetProducts().ForEach(prod =>
                    {
                        ls.Add(new ProductViewModel(prod.ID, prod.Img, prod.TypeID, prod.CategoriesID, prod.FunctionID, prod.Title, prod.MetaTitle));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.GetProductsF(nameF).ForEach(prod =>
                    {
                        ls.Add(new ProductViewModel(prod.ID, prod.Img, prod.TypeID, prod.CategoriesID, prod.FunctionID, prod.Title, prod.MetaTitle));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetC(string name)
        {
            if (name == "Kiến trúc")
            {
                try
                {
                    var ls = new List<CategoriesViewModel>();
                    db.GetCt(1).ForEach(cate =>
                    {
                        ls.Add(new CategoriesViewModel(cate.ID, cate.Title, cate.MetaTitle, cate.FunctionID));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (name == "Nội thất")
            {
                try
                {
                    var ls = new List<CategoriesViewModel>();
                    db.GetCt(2).ForEach(cate =>
                    {
                        ls.Add(new CategoriesViewModel(cate.ID, cate.Title, cate.MetaTitle, cate.FunctionID));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            else if(name == "Xây dựng")
            {
                try
                {
                    var ls = new List<CategoriesViewModel>();
                    db.GetCt(3).ForEach(cate =>
                    {
                        ls.Add(new CategoriesViewModel(cate.ID, cate.Title, cate.MetaTitle, cate.FunctionID));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetT(string name) 
        {
            try
            {
                var ls = new List<TypeeViewModel>();
                db.GetT(name).ForEach(tp =>
                {
                    ls.Add(new TypeeViewModel(tp.ID, tp.CategoriesID, tp.Title, tp.MetaTitle));
                });
                return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProductC(string nameC)
        {
            try
            {
                var ls = new List<ProductViewModel>();
                    db.GetProductsC(nameC).ForEach(prod =>
                    {
                        ls.Add(new ProductViewModel(prod.ID, prod.Img, prod.TypeID, prod.CategoriesID, prod.FunctionID, prod.Title, prod.MetaTitle));
                    });
                    return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProductCT(string nameC, string nameT)
        {
            try
            {
                var ls = new List<ProductViewModel>();
                db.GetProductsCT(nameC , nameT).ForEach(prod =>
                {
                    ls.Add(new ProductViewModel(prod.ID, prod.Img, prod.TypeID, prod.CategoriesID, prod.FunctionID, prod.Title, prod.MetaTitle));
                });
                return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            MyDb myDb = new MyDb();
            var file = model.ImageFile;
            var img = "/img/" + file.FileName;
            var title = model.Title;
            var metaTitle = model.MetaTitle;
            var functionID = db.GetFId(model.FunctionName);
            var categoriesID = db.GetCId(model.CategoriesName);
            var TypeeID = db.GetTId(model.TypeName);
            var fileDetail = model.ImgDetails;
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            db.Create(img, TypeeID, categoriesID, functionID, title, metaTitle);
            var max = myDb.Products.Where(pr => pr.ID > 0).Max(p => p.ID);
            productViewModels.Add(new ProductViewModel(max, img, TypeeID, categoriesID, functionID, title, metaTitle));
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/img/" + file.FileName));
                //BinaryReader reader = new BinaryReader(file.InputStream);
            }
            if (fileDetail != null)
            {
                //var max = myDb.Products.Where(pr => pr.ID > 0).Max(p => p.ID);
                foreach (var item in fileDetail)
                {
                    ProductDetail productDetail = new ProductDetail();
                    string anh = "/img/" + item.FileName;
                    productDetail.Img = anh;
                    productDetail.ProductId = max;
                    myDb.ProductDetails.Add(productDetail);
                    myDb.SaveChanges();
                    item.SaveAs(Server.MapPath(anh));
                }
            }
            return Json(new { code = 200, ls = productViewModels }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteProduct(string id)
        {
            int ID = int.Parse(id);
            try
            {
                MyDb mydb = new MyDb();
                var product = mydb.Products.Where(p => p.ID == ID).FirstOrDefault();
                string deletefile = Server.MapPath(product.Img);
                System.IO.File.Delete(deletefile);
                var productDetail = mydb.ProductDetails.Where(p => p.ProductId == ID).ToList();
                foreach (var item in productDetail)
                {
                    string de = Server.MapPath(item.Img);
                    System.IO.File.Delete(de);
                }
                mydb.ProductDetails.RemoveRange(productDetail);
                mydb.Products.Remove(product);
                mydb.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetAllImg(string id)
        {
            try
            {
                return Json(new { code = 200, ls = db.GetAllImg(int.Parse(id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetProductEdit(string id)
        {
            try
            {
                var ls = new List<EditProductViewModel>();
                db.GetEdit(int.Parse(id)).ForEach(p =>
                {
                    ls.Add(new EditProductViewModel(p.ID, p.Img, p.TypeID, p.CategoriesID, p.FunctionID, p.Title, p.MetaTitle));
                });
                return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetEditImg(string id)
        {
            try
            {
                var ls = new List<ProductDetailViewModel>();
                db.GetEditImgDetail(int.Parse(id)).ForEach(p => 
                {
                    ls.Add(new ProductDetailViewModel(p.Id, p.Img, p.ProductId));
                });
                return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet); 
            }
        }
        public ActionResult DeleteImgEdit(string id)
        {
            try
            {
                int ID = int.Parse(id);
                MyDb myDb = new MyDb();
                var img = myDb.ProductDetails.Where(p => p.Id == ID).FirstOrDefault();
                myDb.ProductDetails.Remove(img);
                myDb.SaveChanges();
                string deletefile = Server.MapPath(img.Img);
                System.IO.File.Delete(deletefile);
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult EditProduct(CreateProductViewModel model)
        {
            MyDb mydb = new MyDb();
            int ID = int.Parse(model.ID);
            var title = model.Title;
            var metaTitle = model.MetaTitle;
            var functionID = db.GetFId(model.FunctionName);
            var categoriesID = db.GetCId(model.CategoriesName);
            var TypeeID = db.GetTId(model.TypeName);
            var fileDetail = model.ImgDetails;
            var file = model.ImageFile;
            var product = mydb.Products.Where(p => p.ID == ID).FirstOrDefault();
            var ls = new List<ProductViewModel>();
            
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/img/" + file.FileName));
                var img = "/img/" + file.FileName;
                ls.Add(new ProductViewModel(ID, img, TypeeID, categoriesID, functionID, title, metaTitle));
                string deletefile = Server.MapPath(product.Img);
                System.IO.File.Delete(deletefile);
                product.Img = img;
                product.TypeID = TypeeID;
                product.CategoriesID = categoriesID;
                product.FunctionID = functionID;
                product.Title = title;
                product.MetaTitle = metaTitle;
                mydb.SaveChanges();

            }
            else
            {
                ls.Add(new ProductViewModel(ID, product.Img, TypeeID, categoriesID, functionID, title, metaTitle));
                product.TypeID = TypeeID;
                product.CategoriesID = categoriesID;
                product.FunctionID = functionID;
                product.Title = title;
                product.MetaTitle = metaTitle;
                mydb.SaveChanges();
            }

            if (fileDetail != null)
            {
                //var max = myDb.Products.Where(pr => pr.ID > 0).Max(p => p.ID);
                foreach (var item in fileDetail)
                {
                    ProductDetail productDetail = new ProductDetail();
                    string anh = "/img/" + item.FileName;
                    productDetail.Img = anh;
                    productDetail.ProductId = ID;
                    mydb.ProductDetails.Add(productDetail);
                    mydb.SaveChanges();
                    item.SaveAs(Server.MapPath("/img/" + item.FileName));
                }
            }
            return Json(new { code = 200, ls = ls }, JsonRequestBehavior.AllowGet);
        }
    }
}