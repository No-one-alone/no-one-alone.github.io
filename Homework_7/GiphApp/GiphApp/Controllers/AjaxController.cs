//using GiphyApp.DAL;
//using GiphyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GiphApp.Controllers
{
    public class AjaxController : Controller
    {
        


        public JsonResult GetGiphyAPIimage(string enteredWord)
        {
          
            string url = "https://api.giphy.com/v1/stickers/translate?api_key=" +
                         System.Web.Configuration.WebConfigurationManager.AppSettings["SecretGiphyAPIKey"] +
                         "&s=" + enteredWord;

      
            WebRequest webRequest = WebRequest.Create(url);

    
            Stream dataStream = webRequest.GetResponse().GetResponseStream();

          
            var processedData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .DeserializeObject(new StreamReader(dataStream)
                                  .ReadToEnd());

          

         
            return Json(processedData, JsonRequestBehavior.AllowGet);
        }
    }
}