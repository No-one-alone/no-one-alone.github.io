using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


// added these
using WorldWideImporters.Models;
//using WorldWideImporters.ViewModels;


namespace WorldWideImporters.Controllers
{
    public class HomeController : Controller
    {
        public WorldWideImportersContext database = new WorldWideImportersContext();
  

        public ActionResult Index(string query)
        {
            DisplayModel vm = new DisplayModel();

            if(query == null || query == "")
            {
                ViewBag.show = false;

                return View();
            }
            else
            {
                ViewBag.show = true;

                return View(database.People.Where(x => x.FullName.ToUpper().Contains(query.ToUpper())).ToList());
            }
           
        }


        public ActionResult Details(int? id)
        {
            Person vm = database.People.Find(id);

            return View("Details", vm);
        }















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}