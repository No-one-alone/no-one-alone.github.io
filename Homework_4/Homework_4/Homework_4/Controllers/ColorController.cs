
// This file specifies the controller to process the input colors from the user,
// create a mixed color result, and return it to the View.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added these
using System.Diagnostics; // Used for debugging
using System.Drawing; // used for creating the color display to pass to the View via Color and ColorTranslator.
using System.Text.RegularExpressions; // used for Regular Expression matching.

/// <summary>
/// This is the namespace which contians the controller functions for the project.
/// </summary>
namespace Homework_4.Controllers
{
    /// <summary>
    /// This class that actually contains the controller functions.
    /// Note the use of the Controller extension.
    /// </summary>
    public class ColorController : Controller
    {
        
        /// <summary>
        /// This is the default Controller function for the ColorChooser option.
        /// It sends a GET request to the server.
        /// </summary>
        /// <returns>Returns the View with ViewBag.show set to false.</returns>
        [HttpGet]
        public ActionResult ColorChooser()
        {
            ViewBag.show = false;
            return View();
        }

        /// <summary>
        /// This is the non-default Controller function for the ColorChooser Option
        /// </summary>
        /// <param name="firstColor">The first color submitted by the user</param>
        /// <param name="secondColor">The second color submitted by the user</param>
        /// <returns>Returns the View with the appropriate attributes set to the correct color display or error value</returns>
        [HttpPost]
        public ActionResult ColorChooser(String firstColor, string secondColor)
        {
            // Extracts the Hexadecimal color code in the first input from the query string
            firstColor = Request.Form["first_color"];

            // Extracts the Hexadecimal color code in the second input from the query string
            secondColor = Request.Form["second_color"];

            // This is test/debug code.
           // FirstColor = FirstColor.Remove(1, 1);
           // FirstColor = FirstColor + 'G';


            // This is a ViewBag attribute set to an empty string until a suitable message is created.   
            ViewBag.message = "";

            // This code block creates the mix color result from the two input colors and formats it for display to the View after checking if user input was valid.
            // if user input was invalid, then an error message is prepared for the user instead.
            if (firstColor != null && secondColor != null && Regex.IsMatch(firstColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$") && Regex.IsMatch(secondColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$"))
            {
                // this debugging code
                Debug.WriteLine(firstColor);
                Debug.WriteLine(secondColor);

                // These are variables to store the components that make up the ARGB structure.
                int alphaComponent, redComponent, greenComponent, blueComponent;

                // These translate the HTML color representation to a GDI+ Color structure.
                Color firstColor_ARGB = ColorTranslator.FromHtml(firstColor);
                Color secondColor_ARGB = ColorTranslator.FromHtml(secondColor);

                // This code block invokes the following algorithm:
                // if the sum of the alpha, red, green, or blue color components is equal or greater than 255,
                // then the color is clamped to the value of 255.
                // if the summed color value is less than 255, then the summed result is displayed as is.
                alphaComponent = firstColor_ARGB.A + secondColor_ARGB.A >= 255 ? 255 : firstColor_ARGB.A + secondColor_ARGB.A;

                redComponent = firstColor_ARGB.R + secondColor_ARGB.R >= 255 ? 255 : firstColor_ARGB.R + secondColor_ARGB.R;

                greenComponent = firstColor_ARGB.G + secondColor_ARGB.G >= 255 ? 255 : firstColor_ARGB.G + secondColor_ARGB.G;

                blueComponent = firstColor_ARGB.B + secondColor_ARGB.B >= 255 ? 255 : firstColor_ARGB.B + secondColor_ARGB.B;

                // This creates the new mixed color from the color components generated above.
                string colorMixResult = ColorTranslator.ToHtml(Color.FromArgb(alphaComponent, redComponent, greenComponent, blueComponent ));
           
                // This sets the ViewBag attribute to true to indicate that the View should show a color display an answer.
                ViewBag.show = true;

                // This code block formats the colors for display in the View along with some additional symbols.
                ViewBag.firstInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + firstColor + ";";

                ViewBag.secondInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + secondColor + ";";

                ViewBag.outputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + colorMixResult + ";";

            }
            else // This indicates that an error message should be shown to the user in the View due to invald inputs.
            {
                ViewBag.show = false;
                ViewBag.message = "Input was invalid!";
                
            }

            return View(); // This returns the View.
        }
    }
}