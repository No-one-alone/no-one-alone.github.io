using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionHouse.Models;

//added this
using AuctionHouse.DAL;

namespace AuctionHouse.Controllers
{
    public class ItemsController : Controller
    {
        private AuctionHouseContext db = new AuctionHouseContext();


        // added this for ajax part
        /// <summary>
        /// Makes a request of the database to get the list of bids in list form.
        /// </summary>
        /// <param name="id">Needs ID of a listing</param>
        /// <returns>returns List of bids in JSON format</returns>
        [HttpGet]
        public JsonResult BidUpdateRequest(int? id)
        {
            //Gets all bids associated with the specified item ID
            var bids = db.Bids.Where(bid => bid.ItemID == id)
                              .Select(bid => new { Buyer = bid.Buyer.BuyerName, Amount = bid.Price })
                              .OrderByDescending(b => b.Amount)
                              .ToList();

            return Json(bids, JsonRequestBehavior.AllowGet); //Returns bid list in JSON format
        }


        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Seller);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "SellerName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemName,Description,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "SellerName", item.SellerID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "SellerName", item.SellerID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemName,Description,SellerID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerID = new SelectList(db.Sellers, "ID", "SellerName", item.SellerID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);


            if(item != null)
            {
               
                List<Bid> bids = db.Bids.Where(x => x.ItemID == id).ToList();

                
                if (bids.Count > 0)
                {
                    return RedirectToAction("Index");

                }

            }


            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
