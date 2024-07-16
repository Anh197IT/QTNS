using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ql_nha_sach.Models;

namespace ql_nha_sach.Controllers
{
    public class SACHesController : Controller
    {
        private Model1 db = new Model1();

        // GET: SACHes
        public ActionResult Index(string searchString)
        { 
            var sACHes = db.SACHes.Include(s => s.LOAISACH);
            if(!String.IsNullOrEmpty(searchString))
            {
                sACHes = db.SACHes.Where(s => s.Tensach.Contains(searchString));
            }    
            return View(sACHes.ToList());
        }

        // GET: SACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACHes/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Maloai = new SelectList(db.LOAISACHes, "Maloai", "Tenloai");
            return View();
        }

        // POST: SACHes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "MaSach,Tensach,Tentacgia,NXB,Ngaynhap,Soluongnhap,Maloai,Giaban")] SACH sACH)
    {
        if (ModelState.IsValid)
        {
            db.SACHes.Add(sACH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Maloai = new SelectList(db.LOAISACHes, "Maloai", "Tenloai", sACH.Maloai);
        return View(sACH);
    }

        // GET: SACHes/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloai = new SelectList(db.LOAISACHes, "Maloai", "Tenloai", sACH.Maloai);
            return View(sACH);
        }

        // POST: SACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,Tensach,Anhbia,Tentacgia,NXB,Ngaynhap,Soluongnhap,Maloai")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maloai = new SelectList(db.LOAISACHes, "Maloai", "Tenloai", sACH.Maloai);
            return View(sACH);
        }
        [HttpGet]
        // GET: SACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
