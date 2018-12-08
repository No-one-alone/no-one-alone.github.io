// This is the Controller file created to handle the AJAX component.
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

/// <summary>
/// This is the namespace for our controller
/// </summary>
namespace GiphApp.Controllers
{
    /// <summary>
    /// This is our controller class for handling AJAX.
    /// </summary>
    public class AjaxController : Controller
    {
        // this creates a database context object for later use.
        private OurSearchRequestsContext database = new OurSearchRequestsContext();

        /// <summary>
        /// This our JsonResult method for obtaining GIFs for "interesting" words.
        /// </summary>
        /// <param name="enteredWord"> the word entered by the user.</param>
        /// <returns>the json output.</returns>
        [HttpGet]
        public JsonResult GetGiphyAPIimage(string enteredWord)
        {
            // this our string for the uri created from the giphy path, our secret giphy key, and our "interesting" word.
            string uri = "https://api.giphy.com/v1/stickers/translate?api_key=" +
                         System.Web.Configuration.WebConfigurationManager.AppSettings["SecretGiphyAPIKey"] +
                         "&s=" + enteredWord;

            // this creates our web request.
            WebRequest webRequest = WebRequest.Create(uri);

            // This obtains the necessary JSON data.
            Stream dataStream = webRequest.GetResponse().GetResponseStream();

            // This processes and parses the obtained JSON data.
            var processedData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .DeserializeObject(new StreamReader(dataStream)
                                  .ReadToEnd());

            // This creates a search requests object for storing the relevant data that we wish to log to our database.
            SearchRequests searchRequestsEntry = new SearchRequests();

            // This stores the user host address.
            searchRequestsEntry.IPAddressOfRequestor = Request.UserHostAddress; 

            // This stores the entered word that was considered "interesting".
            searchRequestsEntry.RequestWord = enteredWord;

            // This stores the client's browser type.
            searchRequestsEntry.ClientBrowserAgentType = Request.Browser.Type;

            //This saves the request details to the database.
            database.Entries.Add(searchRequestsEntry);
            database.SaveChanges();
        
            // This returns the JSON data.
            return Json(processedData, JsonRequestBehavior.AllowGet);
        }
    }
}