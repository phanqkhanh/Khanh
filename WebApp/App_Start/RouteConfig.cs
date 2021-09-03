using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Architecture",
                url: "kien-truc",
                defaults: new { controller = "Home", action = "Architecture", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Furniture",
                url: "noi-that",
                defaults: new { controller = "Home", action = "Furniture", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Construct",
                url: "xay-dung",
                defaults: new { controller = "Home", action = "Construct", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "route1",
                url: "{me-ta}/{categories}",
                defaults: new {controller = "Home", action ="Categories", categories = UrlParameter.Optional}
                );
            routes.MapRoute(
                name: "route2",
                url: "{me-ta}/{categories}/{type}",
                defaults: new { controller = "Home", action = "Types", type = UrlParameter.Optional , categories =UrlParameter.Optional}
                );
            routes.MapRoute(
                name: "product",
                url: "{me-ta}/{categories}/{type}/{product}",
                defaults: new {controller = "Home", action = "Product"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
