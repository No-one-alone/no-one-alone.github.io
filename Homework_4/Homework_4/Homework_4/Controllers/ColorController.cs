using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added this
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Homework_4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [HttpGet]
        public ActionResult ColorChooser()
        {
            ViewBag.show = false;
            return View();
        }

        [HttpPost]
        public ActionResult ColorChooser(String FirstColor, string SecondColor)
        {
            FirstColor = Request.Form["first_color"];
            SecondColor = Request.Form["second_color"];

           // FirstColor = FirstColor.Remove(1, 1);

           // FirstColor = FirstColor + 'G';


            ViewBag.message = "";
            if (FirstColor != null && SecondColor != null && Regex.IsMatch(FirstColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$") && Regex.IsMatch(SecondColor, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$"))
            {

                Debug.WriteLine(FirstColor);

                Debug.WriteLine(SecondColor);

                int AlphaComponent, RedComponent, GreenComponent, BlueComponent;


                Color FirstColor_ARGB = ColorTranslator.FromHtml(FirstColor);

                Color SecondColor_ARGB = ColorTranslator.FromHtml(SecondColor);


                AlphaComponent = FirstColor_ARGB.A + SecondColor_ARGB.A >= 255 ? 255 : FirstColor_ARGB.A + SecondColor_ARGB.A;

                RedComponent = FirstColor_ARGB.R + SecondColor_ARGB.R >= 255 ? 255 : FirstColor_ARGB.R + SecondColor_ARGB.R;

                GreenComponent = FirstColor_ARGB.G + SecondColor_ARGB.G >= 255 ? 255 : FirstColor_ARGB.G + SecondColor_ARGB.G;

                BlueComponent = FirstColor_ARGB.B + SecondColor_ARGB.B >= 255 ? 255 : FirstColor_ARGB.B + SecondColor_ARGB.B;

                string ColorMixResult = ColorTranslator.ToHtml(Color.FromArgb(AlphaComponent, RedComponent, GreenComponent, BlueComponent ));
           

                ViewBag.show = true;

                ViewBag.firstInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + FirstColor + ";";

                ViewBag.secondInputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + SecondColor + ";";

                ViewBag.outputColor = "width: 70px; height: 70px; border: 1px solid #D3D3D3; background:" + ColorMixResult + ";";

            }
            else
            {
                ViewBag.show = false;
                ViewBag.message = "Input was invalid!";
                
            }

            return View();
        }
    }
}