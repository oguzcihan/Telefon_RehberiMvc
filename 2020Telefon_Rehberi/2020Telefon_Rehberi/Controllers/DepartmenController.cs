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
    public class DepartmenController : Controller
    {
        private telefonContext db = new telefonContext();

        // GET: Departmen
        public ActionResult Index()
        {
            return View(db.depts.ToList());
        }

        // GET: Departmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.depts.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // GET: Departmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,departmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.depts.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departman);
        }

        // GET: Departmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.depts.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,departmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }

        // GET: Departmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.depts.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departman departman = db.depts.Find(id);
            db.depts.Remove(departman);
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
