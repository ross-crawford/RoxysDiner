using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingSystem.DAL;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private BookingContext db = new BookingContext();

        // GET: Booking
        public ActionResult Index(string searchString, string sortOrder)
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Table);
            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(s => s.BookingDateTime.ToShortDateString().Contains(searchString));
            }
            switch (sortOrder)
            {
                default:
                    bookings = bookings.OrderBy(b => b.BookingDateTime);
                    break;
            }
            return View(bookings.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.Bookings.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            return View(bookingModel);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.Customers, "CustomerId", "LastName");
            ViewBag.BookingId = new SelectList(db.Tables, "TableId", "TableNumber");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingDateTime,Duration,PartySize,TableAllocation,BookingComments")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(bookingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.Customers, "CustomerId", "FirstName", bookingModel.BookingId);
            ViewBag.BookingId = new SelectList(db.Tables, "TableId", "TableId", bookingModel.BookingId);
            return View(bookingModel);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.Bookings.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.Customers, "CustomerId", "FirstName", bookingModel.BookingId);
            ViewBag.BookingId = new SelectList(db.Tables, "TableId", "TableId", bookingModel.BookingId);
            return View(bookingModel);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingDateTime,Duration,PartySize,TableAllocation,BookingComments")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.Customers, "CustomerId", "FirstName", bookingModel.BookingId);
            ViewBag.BookingId = new SelectList(db.Tables, "TableId", "TableId", bookingModel.BookingId);
            return View(bookingModel);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.Bookings.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            return View(bookingModel);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingModel bookingModel = db.Bookings.Find(id);
            db.Bookings.Remove(bookingModel);
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
