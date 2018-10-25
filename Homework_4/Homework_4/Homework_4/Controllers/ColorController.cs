using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added this
using System.Diagnostics;
using System.Drawing;

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
        public ActionResult ColorChooser(String ColorOne, string ColorTwo)
        {
            ColorOne = Request.Form["first_color"];
            ColorTwo = Request.Form["second_color"];

            Debug.WriteLine(ColorOne);

            Debug.WriteLine(ColorTwo);

            int color_A;

            int color_R;

            int color_B;

            int color_G;

            Color rgb_c1 = ColorTranslator.FromHtml(ColorOne);

            Color rgb_c2 = ColorTranslator.FromHtml(ColorTwo);


            if(rgb_c1.A + rgb_c2.A >= 255)
            {
                color_A = 255;
            }
            else
            {
                color_A = rgb_c1.A + rgb_c2.A;
            }



            if (rgb_c1.R + rgb_c2.R >= 255)
            {
                color_R = 255;
            }
            else
            {
                color_R = rgb_c1.R + rgb_c2.R;
            }



            if (rgb_c1.B + rgb_c2.B >= 255)
            {
                color_B = 255;
            }
            else
            {
                color_B = rgb_c1.B + rgb_c2.B;
            }



            if (rgb_c1.G + rgb_c2.G >= 255)
            {
                color_G = 255;
            }
            else
            {
                color_G = rgb_c1.G+ rgb_c2.G;
            }

            string mixColor = ColorTranslator.ToHtml(Color.FromArgb(color_A, color_R, color_B, color_G));

            if(ColorOne != null && ColorTwo != null)
            {
                ViewBag.show = true;

                ViewBag.shape = "width: 70px; height: 70px; border: 1px soild #000; background:" + ColorOne + ";";

                ViewBag.shape1 = "width: 70px; height: 70px; border: 1px soild #000; background:" + ColorTwo + ";";

                ViewBag.shape2 = "width: 70px; height: 70px; border: 1px soild #000; background:" + mixColor + ";";

            }


            return View();




        }


    }
}