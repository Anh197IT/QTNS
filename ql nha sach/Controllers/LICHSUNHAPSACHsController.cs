using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ql_nha_sach.Models;

namespace ql_nha_sach.Controllers
{
    public class LichSuNhapSachController : Controller
    {
        private Model1 db = new Model1();

        // GET: LichSuNhapSach
        public ActionResult Index()
        {
            var lichSuNhapSach = db.LichSuNhapSaches.Include(l => l.SACH).ToList();
            return View(lichSuNhapSach);
        }

        // GET: LichSuNhapSach/Details/5
        public ActionResult Details(int id)
        {
            LichSuNhapSach lichSuNhapSach = db.LichSuNhapSaches.Find(id);
            if (lichSuNhapSach == null)
            {
                return HttpNotFound();
            }
            return View(lichSuNhapSach);
        }

        // GET: LichSuNhapSach/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "Tensach");
            return View();
        }

        // POST: LichSuNhapSach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSach,NgayNhap,SoLuong")] LichSuNhapSach lichSuNhapSach)
        {
            if (ModelState.IsValid)
            {
                db.LichSuNhapSaches.Add(lichSuNhapSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "Tensach", lichSuNhapSach.MaSach);
            return View(lichSuNhapSach);
        }

        // GET: LichSuNhapSach/Edit/5
        public ActionResult Edit(int id)
        {
            LichSuNhapSach lichSuNhapSach = db.LichSuNhapSaches.Find(id);
            if (lichSuNhapSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "Tensach", lichSuNhapSach.MaSach);
            return View(lichSuNhapSach);
        }

        // POST: LichSuNhapSach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSach,NgayNhap,SoLuong")] LichSuNhapSach lichSuNhapSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichSuNhapSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "Tensach", lichSuNhapSach.MaSach);
            return View(lichSuNhapSach);
        }

        // GET: LichSuNhapSach/Delete/5
        public ActionResult Delete(int id)
        {
            LichSuNhapSach lichSuNhapSach = db.LichSuNhapSaches.Find(id);
            if (lichSuNhapSach == null)
            {
                return HttpNotFound();
            }
            return View(lichSuNhapSach);
        }

        // POST: LichSuNhapSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            LichSuNhapSach lichSuNhapSach = db.LichSuNhapSaches.Find(Id);
            db.LichSuNhapSaches.Remove(lichSuNhapSach);
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
