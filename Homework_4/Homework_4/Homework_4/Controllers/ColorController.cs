
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
        /// <param name="FirstColor">The first color submitted by the user</param>
        /// <param name="SecondColor">The second color submitted by the user</param>
        /// <returns>Returns the View with the appropriate attributes set to the correct color display or error value</returns>
        [HttpPost]
        public ActionResult ColorChooser(String FirstColor, string SecondColor)
        {
            // Extracts the Hexadecimal color code in the first input from the query string
            FirstColor = Request.Form["first_color"];

            // Extracts the Hexadecimal color code in the second input from the query string
            SecondColor = Request.Form["second_color"];

            // This is test/debug code.
           // FirstColor = FirstColor.Remove(1, 1);
           // FirstColor = FirstColor + 'G';


            // This is a ViewBag attribute set to an empty string until a suitable message is created.   
            ViewBag.message = "";

            // This code block creates the mix color result from the two input colors and formats it for display to the View after checking if user input was valid.
            // if user input was invalid, then an error message is prepared for the user instead.
            if (FirstColor != null && SecondColor != null && Regex.IsMatch(FirstColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$") && Regex.IsMatch(SecondColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$"))
            {
                // this debugging code
                Debug.WriteLine(FirstColor);
                Debug.WriteLine(SecondColor);

                // These are variables to store the components that make up the ARGB structure.
                int AlphaComponent, RedComponent, GreenComponent, BlueComponent;

                // These translate the HTML color representation to a GDI+ Color structure.
                Color FirstColor_ARGB = ColorTranslator.FromHtml(FirstColor);
                Color SecondColor_ARGB = ColorTranslator.FromHtml(SecondColor);

                // This code block invokes the following algorithm:
                // if the sum of the alpha, red, green, or blue color components is equal or greater than 255,
                // then the color is clamped to the value of 255.
                // if the summed color value is less than 255, then the summed result is displayed as is.
                AlphaComponent = FirstColor_ARGB.A + SecondColor_ARGB.A >= 255 ? 255 : FirstColor_ARGB.A + SecondColor_ARGB.A;

                RedComponent = FirstColor_ARGB.R + SecondColor_ARGB.R >= 255 ? 255 : FirstColor_ARGB.R + SecondColor_ARGB.R;

                GreenComponent = FirstColor_ARGB.G + SecondColor_ARGB.G >= 255 ? 255 : FirstColor_ARGB.G + SecondColor_ARGB.G;

                BlueComponent = FirstColor_ARGB.B + SecondColor_ARGB.B >= 255 ? 255 : FirstColor_ARGB.B + SecondColor_ARGB.B;

                // This creates the new mixed color from the color components generated above.
                string ColorMixResult = ColorTranslator.ToHtml(Color.FromArgb(AlphaComponent, RedComponent, GreenComponent, BlueComponent ));
           
                // This sets the ViewBag attribute to true to indicate that the View should show a color display an answer.
                ViewBag.show = true;

                // This code block formats the colors for display in the View along with some additional symbols.
                ViewBag.firstInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + FirstColor + ";";

                ViewBag.secondInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + SecondColor + ";";

                ViewBag.outputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + ColorMixResult + ";";

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