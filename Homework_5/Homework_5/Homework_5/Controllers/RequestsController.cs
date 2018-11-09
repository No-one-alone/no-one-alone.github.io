// This file is the requests controller for the "make a request" and "view requests" web pages of our project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// These were added to allow access to the model class and data access layer files of our project.
using Homework_5.DAL;
using Homework_5.Models;

/// <summary>
/// This is the namespace of our requests controller.
/// </summary>
namespace Homework_5.Controllers
{

    /// <summary>
    /// This the class that actually defines our requests controller for the project.
    /// </summary>
    public class RequestsController : Controller
    {
        // GET:
        /// <summary>
        /// This creates a new instance of our database for accessing its data as seen below.
        /// </summary>
        private RequestContext database = new RequestContext();

        /// <summary>
        /// This is a GET request style ActionResult controller function for returning the home page.
        /// </summary>
        /// <returns> returns the homepage</returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Your home page.";
            
            return View();
        }

        // GET: Requests
        /// <summary>
        /// This is a GET request style ActionResult controller function for returning a sort list of the database entries to the "View Requests" webpage.
        /// </summary>
        /// <returns>returns a list sorted oldest-first to View Requests</returns>
        [HttpGet]
        public ActionResult Listing()
        {
            List<Request> list = database.Requests.ToList(); // Converts database object to list object.
            var sortedList = list.OrderBy(time => time.DateTimeOfRequest); // sorted the list by time so that oldest entry appears first.
            return View(sortedList); // returns the sorted list to the View defined by Listing
        }

        //GET: Requests/Create
        /// <summary>
        /// This is a GET request style Action Result controller function for returning the Make a Request web page.
        /// </summary>
        /// <returns>Just returns the webpage defined by Create. </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// This is a POST request style Action Result controller for getting the form data entered by the user after being submitted and redirecting the user to the View Requests webpage.
        /// </summary>
        /// <param name="request">Takes in the user entered data values</param>
        /// <returns>Takes the user to the View requests webpage if all data entered was valid, otherwise returns the make a request page as is</returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestExplanation, Permission, DateTimeOfRequest")] Request request)
        {
            if (ModelState.IsValid) // checks if all data entered was in line with the model requirements.
            {
                request.DateTimeOfRequest = DateTime.Now; // Sets the DateTimeOfRequest field to the current time as our means of time stamping requests as they are made.
                database.Requests.Add(request); // Adds the user supplied data to the database object.
                database.SaveChanges(); // Saves the changes due to new data to the database as new database entries.

                // Redirect POST request to GET request as per required GET-POST-Redirect pattern.
                // Basically takes the user to the View Requests webpage after making a succesful submission on the Make a Request webpage.
                return RedirectToAction("Listing");
            }

            // returns current Make a Request webpage in the event of the user supplying invalid data.
            return View(request);
        }
    }
}