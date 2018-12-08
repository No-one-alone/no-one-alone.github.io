
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

/// <summary>
/// this the namespace for our giph app solution.
/// </summary>
namespace GiphApp
{
    /// <summary>
    /// Our RouteConfig class.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Our standard boiler plate function for routes.
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // This is the new non-default custom route we created.
            routes.MapRoute(
                name: "GiphyImages",
                url: "Giphy/Image/{enteredWord}",
                defaults: new { Controller = "Ajax", action = "GetGiphyAPIimage", enteredWord = UrlParameter.Optional }

                );

            // This is the default route.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
