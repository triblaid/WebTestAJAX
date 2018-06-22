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
    public class CompanysController : Controller
    {
        private DatabaseTestAJAXEntities db = new DatabaseTestAJAXEntities();

        // GET: Companys
        public ActionResult Index()
        {
            return View(db.Companys.ToList());
        }

        // GET: Companys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companys companys = db.Companys.Find(id);
            if (companys == null)
            {
                return HttpNotFound();
            }
            return View(companys);
        }

        // GET: Companys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Email")] Companys companys)
        {
            if (ModelState.IsValid)
            {
                db.Companys.Add(companys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companys);
        }

        // GET: Companys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companys companys = db.Companys.Find(id);
            if (companys == null)
            {
                return HttpNotFound();
            }
            return View(companys);
        }

        // POST: Companys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Email")] Companys companys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companys);
        }

        // GET: Companys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companys companys = db.Companys.Find(id);
            if (companys == null)
            {
                return HttpNotFound();
            }
            return View(companys);
        }

        // POST: Companys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Companys companys = db.Companys.Find(id);
            db.Companys.Remove(companys);
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
