// This is the controller file for the home page i.e. our landing page.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// This is the namespace for our home controller.
/// </summary>
namespace Homework_5.Controllers
{

    /// <summary>
    /// This is the actual class that defines the home controller.
    /// </summary>
    public class HomeController : Controller
    {

        // GET: Requests
        /// <summary>
        /// This is the controller ActionResult function for the home page.
        /// </summary>
        /// <returns>It returns the View.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}


