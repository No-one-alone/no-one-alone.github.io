
// This file contains the controller functions for the Index "Home" page, the Converter page, and the ColorChooser page.

using System; // necessary for datatype conversion functions and string methods.

//added this
using System.Diagnostics; // Required for debugging functions
using System.Web.Mvc; // required for MVC web


/// <summary>
/// This the namespace for the project which contains the various controllers needed for manipulating user inputs and returning them to the Views.
/// </summary>
namespace Homework_4.Controllers
{
    /// <summary>
    /// This the name of the class which actually contains the controller functions. Note the "Controller" extension.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Controller function for Index page. 
        /// </summary>
        /// <returns>Just returns the View unmodified.</returns>
        public ActionResult Index()
        {
            return View();
        }

        
        /// <summary>
        /// This is the Controller function for the mile distance Converter web page.
        /// Notice that it uses a GET request to the server.
        /// </summary>
        /// <returns>The View with a message: 
        /// A string with the correct conversion of the supplied mile distance if user input was valid. 
        /// A string with an error notice for the user if user input was invalid</returns>
        [HttpGet]
        public ActionResult Converter()
        {
            // These are meant to track if the measure and unit inputs were valid or invalid using the ViewBag.
            ViewBag.checkMeasure = false;
            ViewBag.checkUnit = false;


            // This attempts to obtain the number value of the user inputted mile distance. Note use of the Request object.
            double miles = -1;
            ViewBag.checkMeasure = Double.TryParse(Request.QueryString["mile"], out miles);

            // This attempts to obtain the string value of the user inputted conversion unit. Note use of the Request object.
            string unit = Request.QueryString["metric-unit"];

            // These can be used to debug the obtained user inputs.
            Debug.WriteLine(miles);
            Debug.WriteLine(unit);

            // This is used to hold the conversion result.
            double calcedConversion = -1;

            // This code block determines which unit has been specified
            // and then calculates the appropriate conversion from the miles given.
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


            // This holds the message to be displayed to the user.
            string message = "";

            // This large code block creates the message to display to the user provided all inputs were valid.
            // and if any inputs were invalid, then the appropriate error message is generated for display to the user.
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

       
            // This stores the generated message into the ViewBag for later retrieval by the View.
            ViewBag.Message = message;
        
            return View(); // This returns the View.
        }
    }
}
