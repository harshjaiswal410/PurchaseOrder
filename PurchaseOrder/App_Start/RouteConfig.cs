using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PurchaseOrder
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Purchase", action = "GetDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DeleteData",
                url: "{controller}/{action}",
                defaults: new { controller = "Purchase", action = "DeleteDetails", id = UrlParameter.Optional }
            );
        }
    }
}
