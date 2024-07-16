using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ql_nha_sach.Models;

namespace ql_nha_sach.Controllers
{
    public class LOAISACHesController : Controller
    {
        private Model1 db = new Model1();

        // GET: LOAISACHes
        public ActionResult Index()
        {
            return View(db.LOAISACHes.ToList());
        }

        // GET: LOAISACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            if (lOAISACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAISACH);
        }

        // GET: LOAISACHes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAISACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloai,Tenloai")] LOAISACH lOAISACH)
        {
            if (ModelState.IsValid)
            {
                db.LOAISACHes.Add(lOAISACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAISACH);
        }

        // GET: LOAISACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            if (lOAISACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAISACH);
        }

        // POST: LOAISACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloai,Tenloai")] LOAISACH lOAISACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAISACH);
        }

        // GET: LOAISACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            if (lOAISACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAISACH);
        }

        // POST: LOAISACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAISACH lOAISACH = db.LOAISACHes.Find(id);
            db.LOAISACHes.Remove(lOAISACH);
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
