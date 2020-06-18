using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2020Telefon_Rehberi.Models;

namespace _2020Telefon_Rehberi.Controllers
{
    public class telRehbersController : Controller
    {
        private telefonContext db = new telefonContext();

        // GET: telRehbers
        public ActionResult Index()
        {
            var telRehber = db.telRehber.Include(t => t.departman);
            return View(telRehber.ToList());
        }

        // GET: telRehbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telRehber telRehber = db.telRehber.Find(id);
            if (telRehber == null)
            {
                return HttpNotFound();
            }
            return View(telRehber);
        }

        // GET: telRehbers/Create
        public ActionResult Create()
        {
            ViewBag.departmanId = new SelectList(db.depts, "Id", "departmanAdi");
            return View();
        }

        // POST: telRehbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,adSoyad,telefon,yoneticiBilgisi,departmanId")] telRehber telRehber)
        {
            if (ModelState.IsValid)
            {
                db.telRehber.Add(telRehber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmanId = new SelectList(db.depts, "Id", "departmanAdi", telRehber.departmanId);
            return View(telRehber);
        }

        // GET: telRehbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telRehber telRehber = db.telRehber.Find(id);
            if (telRehber == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmanId = new SelectList(db.depts, "Id", "departmanAdi", telRehber.departmanId);
            return View(telRehber);
        }

        // POST: telRehbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,adSoyad,telefon,yoneticiBilgisi,departmanId")] telRehber telRehber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telRehber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmanId = new SelectList(db.depts, "Id", "departmanAdi", telRehber.departmanId);
            return View(telRehber);
        }

        // GET: telRehbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telRehber telRehber = db.telRehber.Find(id);
            if (telRehber == null)
            {
                return HttpNotFound();
            }
            return View(telRehber);
        }

        // POST: telRehbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telRehber telRehber = db.telRehber.Find(id);
            db.telRehber.Remove(telRehber);
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
