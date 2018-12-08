using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


// added these
using WorldWideImporters.Models;
using WorldWideImporters.Models.ViewModels;

/// <summary>
/// This is the namespace that contains the action result functions for homework 6
/// </summary>
namespace WorldWideImporters.Controllers
{
    /// <summary>
    /// This is the class that actually defines HomeController
    /// Note that it is derived from the Controller class.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This creats an instance entity object of the Worldwide importers database for the controllers to interact with.
        /// </summary>
        private WorldWideImportersContext database = new WorldWideImportersContext();
  
        /// <summary>
        ///  This action result function gets the list of people that the match or contain the inputted text.
        /// </summary>
        /// <param name="query">this takes in the inputted user string</param>
        /// <returns>this returns the view possibly with name info</returns>
        [HttpGet]
        public ActionResult Index(string query)
        {
            // the display model
            DisplayModel displaymodel = new DisplayModel();

           

            // this checks if the query contianed text to analyze.
            if (query == "" || query == null)
            {
                ViewBag.show = false; // sets flag to false.

                return View();
            }
            else
            {
                ViewBag.show = true; // sets flag to true.

                ViewBag.querycontent = "Names matching your search: " + query;

                // returns list of possible name matches.
                return View(database.People.Where(name => name.FullName.ToUpper().Contains(query.ToUpper())).ToList());
            }
           
        }


        /// <summary>
        /// This action result function gives us the details of a given person.
        /// Additional details beyond this are given for person who are the primary representative of a given company.
        /// </summary>
        /// <param name="id">takes in a int id.</param>
        /// <returns>returns the display view model.</returns>
        public ActionResult Details(int? id)
        {
            // the display model
            DisplayModel displaymodel = new DisplayModel();

            // finds the person
            displaymodel.MyPerson = database.People.Find(id);

            // initializes check value to false.
            ViewBag.IsPrimaryContactPerson = false;

            // this checks if the customer is a primary representative of a company.
            if(displaymodel.MyPerson.Customers2.Count()>0)
            {
                // sets flag to true.
                ViewBag.IsPrimaryContactPerson = true;


                //this gets the customer id.
                ViewBag.IsP = true;
                int cid = displaymodel.MyPerson.Customers2.FirstOrDefault().CustomerID;
                displaymodel.MyCustomer = database.Customers.Find(cid);

                //this finds the gross sales
                ViewBag.GrossSales = displaymodel.MyCustomer.Orders
                                        .SelectMany(order => order.Invoices)
                                        .SelectMany(invoice => invoice.InvoiceLines)
                                        .Sum(invoiceline => invoiceline.ExtendedPrice);

                //this finds the gross profit
                ViewBag.GrossProfit = displaymodel.MyCustomer.Orders
                                         .SelectMany(order => order.Invoices)
                                         .SelectMany(invoice => invoice.InvoiceLines)
                                         .Sum(invoiceline => invoiceline.LineProfit);

                //this selects the information on the top ten sales
                displaymodel.MyInvoiceLine = displaymodel.MyCustomer.Orders.SelectMany(order => order.Invoices)
                                                .SelectMany(invoice => invoice.InvoiceLines)
                                                .OrderByDescending(invoiceline => invoiceline.LineProfit)
                                                .Take(10)
                                                .ToList();
            }
            return View("Details", displaymodel);
        }
    }
}