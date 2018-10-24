using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added this
using System.Diagnostics;

namespace Homework_4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // changed "about" to "converter" for function name
        [HttpGet]
        public ActionResult Converter()
        {
            // ViewBag.Message = "Your application description page.";

            ViewBag.result = false;
            double miles = Convert.ToDouble(Request.QueryString["mile"]);
            string measure = Request.QueryString["metric-unit"];
            Debug.WriteLine(miles);
            Debug.WriteLine(measure);

            double calcedConversion = 0;

            if(measure == "millimeters")
            {
                calcedConversion = miles * 1609344;
                ViewBag.result = true;
            }
            else if(measure == "centimeters")
            {
                calcedConversion = miles * 160934.4;
                ViewBag.result = true;
            }
            else if (measure == "meters")
            {
                calcedConversion = miles * 1609.344;
                ViewBag.result = true;
            }
            else if (measure == "km")
            {
                calcedConversion = miles * 1.609344;
                ViewBag.result = true;
            }


            string message = "Conversion: " + Convert.ToString(calcedConversion) + " " + measure;
            ViewBag.Message = message;

            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}