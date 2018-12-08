
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//added these
using GiphApp.DAL;
using GiphApp.Models;


namespace GiphApp.Controllers
{
    public class AjaxController : Controller
    {

        private OurSearchRequestsContext database = new OurSearchRequestsContext();

        [HttpGet]
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


             

            // this is for logging requests info
            SearchRequests searchRequestsEntry = new SearchRequests();

            searchRequestsEntry.IPAddressOfRequestor = Request.UserHostAddress; 
            searchRequestsEntry.RequestWord = enteredWord;
           // searchRequestsEntry.ClientBrowserAgentType = Request.UserAgent; 
            searchRequestsEntry.ClientBrowserAgentType = Request.Browser.Type;
            //saves additions
            database.Entries.Add(searchRequestsEntry);
            database.SaveChanges();
          














            return Json(processedData, JsonRequestBehavior.AllowGet);
        }
    }
}