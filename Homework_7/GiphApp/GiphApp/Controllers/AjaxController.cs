using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

//added this
using System.Net;
using System.IO;

namespace GiphApp.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public JsonResult getGIFs(string enteredWord)
        {
            
            string uri = "https://api.giphy.com/v1/stickers/translate?api_key=" +
                         System.Web.Configuration.WebConfigurationManager.AppSettings["key that is used."] +
                         "&s=" + enteredWord;

            
            WebRequest webRequest = WebRequest.Create(uri);

            
            Stream data = webRequest.GetResponse().GetResponseStream();

           
            var parseData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .DeserializeObject(new StreamReader(data)
                                  .ReadToEnd());

            
            return Json(parseData, JsonRequestBehavior.AllowGet);
        }
    }
}