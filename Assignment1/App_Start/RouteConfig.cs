using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "KnowUs",
            url: "knowus",
            defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            //Custom route for Contact (reachus)
            routes.MapRoute(
                name: "ReachUs",
                url: "reachus",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ContactQueries", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
