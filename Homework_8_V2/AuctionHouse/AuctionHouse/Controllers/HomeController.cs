
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//added this
using AuctionHouse.DAL;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        private AuctionHouseContext database = new AuctionHouseContext();

        public ActionResult Index()
        {
            return View(database.Bids.OrderByDescending(time => time.TimeStamp).Take(10).ToList()); 
        }
    }
}