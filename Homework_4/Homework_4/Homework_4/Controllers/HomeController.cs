using System;
//added this
using System.Diagnostics;
using System.Web.Mvc;

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

            ViewBag.check = false;
            bool result = true;
            //  double miles = Convert.ToDouble(Request.QueryString["mile"]);
            double miles = -1;
            result = Double.TryParse(Request.QueryString["mile"], out miles);

            string measure = Request.QueryString["metric-unit"];
            Debug.WriteLine(miles);
            Debug.WriteLine(measure);

            double calcedConversion = -1;

            if(measure == "millimeters")
            {
                calcedConversion = miles * 1609344;
                ViewBag.check = true;
            }
            else if(measure == "centimeters")
            {
                calcedConversion = miles * 160934.4;
                ViewBag.check = true;
            }
            else if (measure == "meters")
            {
                calcedConversion = miles * 1609.344;
                ViewBag.check = true;
            }
            else if (measure == "kilometers")
            {
                calcedConversion = miles * 1.609344;
                ViewBag.check = true;
            }


           
            string message = miles + " miles is equal to " + Convert.ToString(calcedConversion) + " " + measure;
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