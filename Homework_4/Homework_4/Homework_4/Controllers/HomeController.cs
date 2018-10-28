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

            ViewBag.checkMeasure = false;
            ViewBag.checkUnit = false;


            //  double miles = Convert.ToDouble(Request.QueryString["mile"]);
            double miles = -1;
            ViewBag.checkMeasure = Double.TryParse(Request.QueryString["mile"], out miles);

            string unit = Request.QueryString["metric-unit"];


            Debug.WriteLine(miles);
            Debug.WriteLine(unit);

            double calcedConversion = -1;

            if(unit == "millimeters")
            {
                calcedConversion = miles * 1609344;
                ViewBag.checkUnit = true;
            }
            else if(unit == "centimeters")
            {
                calcedConversion = miles * 160934.4;
                ViewBag.checkUnit = true;
            }
            else if (unit == "meters")
            {
                calcedConversion = miles * 1609.344;
                ViewBag.checkUnit = true;
            }
            else if (unit == "kilometers")
            {
                calcedConversion = miles * 1.609344;
                ViewBag.checkUnit = true;
            }


            string message = "";

            if (ViewBag.checkMeasure == true && ViewBag.checkUnit == true)
            {
                message = miles + " miles is equal to " + Convert.ToString(calcedConversion) + " " + unit;
            }
            else if(Request.QueryString["mile"] == null && Request.QueryString["metric-unit"] == null)
            {
                message = "";
            }
            else if(Request.QueryString["mile"] == "" && Request.QueryString["metric-unit"] == null)
            {
                message = "No inputs were provided!";
            }
            else if (Request.QueryString["mile"] == null && Request.QueryString["metric-unit"] == "")
            {
                message = "No inputs were provided!";
            }
            else if (Request.QueryString["mile"] == "" && Request.QueryString["metric-unit"] == "")
            {
                message = "No inputs were provided!";
            }
            else if (Request.QueryString["mile"] == "" && ViewBag.checkUnit == false)
            {
                message = Request.QueryString["mile"] + "Must specify a number and " + Request.QueryString["metric-unit"] + " is not a valid unit!";
            }
            else if (Request.QueryString["mile"] == null && ViewBag.checkUnit == false)
            {
                message = Request.QueryString["mile"] + "Must specify a number and " + Request.QueryString["metric-unit"] + " is not a valid unit!";
            }
            else if (ViewBag.checkMeasure == false && ViewBag.checkUnit == false)
            {
                message = Request.QueryString["mile"] + " is not a number and " + Request.QueryString["metric-unit"] + " is not a valid unit!";
            }
            else if (Request.QueryString["mile"] == null)
            {
                message = "Must specify a number!";
            }
            else if (Request.QueryString["mile"] == "")
            {
                message = "Must specify a number!";
            }
            else if(ViewBag.checkMeasure == false)
            {
                message = Request.QueryString["mile"] + " is not a number!";
            }
            else if (Request.QueryString["metric-unit"] == "")
            {
                message = "Must specify a unit type!";
            }
            else if (Request.QueryString["metric-unit"] == null)
            {
                message = "Must specify a unit type!";
            }
            else if(ViewBag.checkUnit == false)
            {
                message = Request.QueryString["metric-unit"] + " is not a valid unit type!";
            }

       
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