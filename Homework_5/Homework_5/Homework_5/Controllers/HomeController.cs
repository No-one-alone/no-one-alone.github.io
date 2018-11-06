
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Added this
using Homework_5.DAL;
using Homework_5.Models;

namespace Homework_5.Controllers
{
    public class HomeController : Controller
    {

        private RequestContext database = new RequestContext();

        // GET: Requests
        public ActionResult Index()
        {
            return View(database.Requests.ToList());
        }

        //GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestExplanation, Permission, DateTimeOfRequest")] Request request)
        {
            if (ModelState.IsValid)
            {
                database.Requests.Add(request);
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request);
        }














        /*
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
        */

    }
}