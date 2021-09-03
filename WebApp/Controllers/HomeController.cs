using DatabaseProvider;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        MyDb myDb = new MyDb();
        public ActionResult Index()
        {
            ViewBag.count = 0;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.FunctionID == 1).ToList().ForEach(i =>
           {
               ls.Add(new ProductViewModels(i.ID, i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
           });
            return View(ls); 
        }
        public ActionResult Architecture(int? page)
        {
            if (page == null) page = 1;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.FunctionID == 1).ToList().ForEach(i =>
            {
                ls.Add(new ProductViewModels(i.ID,i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
            });
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            return View(ls.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Furniture(int? page)
        {
            if (page == null) page = 1;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.FunctionID == 2).ToList().ForEach(i =>
            {
                ls.Add(new ProductViewModels(i.ID, i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
            });
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            return View(ls.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Construct(int? page)
        {
            if (page == null) page = 1;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.FunctionID == 3).ToList().ForEach(i =>
            {
                ls.Add(new ProductViewModels(i.ID, i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
            });
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            
            return View(ls.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Categories(string categories, int? page)
        {
            if (page == null) page = 1;
            var c = myDb.Categories.Where(p => p.MetaTitle == categories).FirstOrDefault();
            ViewBag.title = c.Title;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.CategoriesID == c.ID).ToList().ForEach(i =>
            {
                ls.Add(new ProductViewModels(i.ID, i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
            });
            
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            return View(ls.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Types(string type, string categories, int? page)
        {
            if (page == null) page = 1;
            var c = myDb.Categories.Where(p => p.MetaTitle == categories).FirstOrDefault();
            var t = myDb.Typees.Where(p => p.MetaTitle == type).FirstOrDefault();
            ViewBag.title = t.Title;
            var ls = new List<ProductViewModels>();
            myDb.Products.Where(p => p.CategoriesID == c.ID && p.TypeID == t.ID).ToList().ForEach(i =>
            {
                ls.Add(new ProductViewModels(i.ID, i.Img, i.TypeID, i.CategoriesID, i.FunctionID, i.Title, i.MetaTitle));
            });
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            return View(ls.ToPagedList(pageNumber, pageSize));
        }
    }
}