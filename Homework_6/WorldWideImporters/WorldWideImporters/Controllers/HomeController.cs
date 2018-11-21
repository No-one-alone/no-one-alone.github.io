using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


// added these
using WorldWideImporters.Models;
using WorldWideImporters.Models.ViewModels;




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
            // Person vm = database.People.Find(id);

            //  return View("Details", vm);

            // the display model
            DisplayModel displaymodel = new DisplayModel();

            // finds the person
            displaymodel.MyPerson = database.People.Find(id);

            // assumes
            ViewBag.IsPrimaryContactPerson = false;

            // check if person

            //added this code!!!d
            if(displaymodel.MyPerson.Customers2.Count()>0)
            {
                ViewBag.IsPrimaryContactPerson = true;


                //lets show the information
                ViewBag.IsP = true;
                int cid = displaymodel.MyPerson.Customers2.FirstOrDefault().CustomerID;
                displaymodel.MyCustomer = database.Customers.Find(cid);

                //find the gross sales
                ViewBag.GrossSales = displaymodel.MyCustomer.Orders.SelectMany(il => il.Invoices).SelectMany(ils => ils.InvoiceLines).Sum(i => i.ExtendedPrice);

                //find the gross profit
                ViewBag.GrossProfit = displaymodel.MyCustomer.Orders.SelectMany(il => il.Invoices).SelectMany(ils => ils.InvoiceLines).Sum(i => i.LineProfit);

                //selects the information on the top ten sales
                displaymodel.MyInvoiceLine = displaymodel.MyCustomer.Orders.SelectMany(x => x.Invoices)
                                                .SelectMany(i => i.InvoiceLines)
                                                .OrderByDescending(i => i.LineProfit)
                                                .Take(10)
                                                .ToList();



            }


            return View("Details", displaymodel);
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