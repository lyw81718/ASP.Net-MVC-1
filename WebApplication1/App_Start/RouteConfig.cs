using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //==============================================================================

            // custom route (traditional way)
            // //movies/released/2019/3
            //routes.MapRoute(
            //    "MoviesbyReleaseDate",                                        //name
            //    "movies/released/{year}/{month}",                             //url, the 'year' and 'month' parameter will be passed to the 'ByReleaseDate' action, so the name of these parameters MUST match
            //    new { controller = "Movies", action = "ByReleaseDate" },      //default route, to 'ByReleaseDate' action in the 'Movies' controller
            //    new { year = @"\d{4}", month = @"\d{2}" });                   //a constraint that specifies that the year and month needs to be 4 and 2 digits, respectively

            //    //new { year = @"2015|2016", month = @"\d{2}" });             //a constraint that specifies that the year needs to be 2015 or 2016

            //==============================================================================

            routes.MapMvcAttributeRoutes();                                     //enable attribute routing, which is cleaner, thus commenting out the above custom route
           


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
