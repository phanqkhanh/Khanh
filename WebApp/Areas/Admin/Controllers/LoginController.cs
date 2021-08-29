using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult login()
        {
            return View();
        }
        public ActionResult LoginIndex() 
        {
            var user = Request["username"];
            var pass = Request["password"];
            return View();
        }
    }
}