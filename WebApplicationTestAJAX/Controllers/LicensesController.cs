using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationTestAJAX;

namespace WebApplicationTestAJAX.Controllers
{
    public class LicensesController : Controller
    {
        private DatabaseTestAJAXEntities db = new DatabaseTestAJAXEntities();

        // GET: Licenses
        public ActionResult Index()
        {
            var licenses = db.Licenses.Include(l => l.Companys).Include(l => l.Towns);
            return View(licenses.ToList());
        }

        // GET: Licenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenses licenses = db.Licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            return View(licenses);
        }

        // GET: Licenses/Create
        public ActionResult Create()
        {
            ViewBag.CompanysId = new SelectList(db.Companys, "Id", "Name");
            ViewBag.TownsId = new SelectList(db.Towns, "Id", "Name");
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Serial,Number,DataStart,DataEnd,CompanysId,TownsId")] Licenses licenses)
        {
            if (ModelState.IsValid)
            {
                db.Licenses.Add(licenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanysId = new SelectList(db.Companys, "Id", "Name", licenses.CompanysId);
            ViewBag.TownsId = new SelectList(db.Towns, "Id", "Name", licenses.TownsId);
            return View(licenses);
        }

        // GET: Licenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenses licenses = db.Licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanysId = new SelectList(db.Companys, "Id", "Name", licenses.CompanysId);
            ViewBag.TownsId = new SelectList(db.Towns, "Id", "Name", licenses.TownsId);
            return View(licenses);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Serial,Number,DataStart,DataEnd,CompanysId,TownsId")] Licenses licenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanysId = new SelectList(db.Companys, "Id", "Name", licenses.CompanysId);
            ViewBag.TownsId = new SelectList(db.Towns, "Id", "Name", licenses.TownsId);
            return View(licenses);
        }

        // GET: Licenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licenses licenses = db.Licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            return View(licenses);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licenses licenses = db.Licenses.Find(id);
            db.Licenses.Remove(licenses);
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
