using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// this is the namespace for our project solution.
/// </summary>
namespace GiphApp.Controllers
{
    /// <summary>
    /// This is the standard pre-built home controller class which extends controller.
    /// </summary>
    public class HomeController : Controller
    {

        // GET: Home
        // standard index action method.
        public ActionResult Index()
        {
            return View();
        }
    }
}