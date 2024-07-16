using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ql_nha_sach.Models;

namespace ql_nha_sach.Controllers
{
    public class NguoidungController : Controller
    {
        Model1 db = new Model1();
        // GET: Nguoidung

        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(TAIKHOAN taikhoan)
        {
            if (db.TAIKHOANs.Any(x => x.TenTK == taikhoan.TenTK))
            {
                ViewBag.Thongbao = "Tên Đăng Nhập Đã Tồn Tại";
                return View();
            }
            else
            {
                db.TAIKHOANs.Add(taikhoan);
                db.SaveChanges();

                Session["TenTK"] = taikhoan.TenTK.ToString();
                return RedirectToAction("Index", "Home");
            }

        }


        //Đawg Xuất
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("login", "Nguoidung");
        }

        //đăng nhâp
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(TAIKHOAN taikhoan)
        {
            var check = db.TAIKHOANs.Where(x => x.TenTK.Equals(taikhoan.TenTK) && x.Matkhau.Equals(taikhoan.Matkhau)).FirstOrDefault();
            if (check != null)
            {
                Session["TenTK"] = taikhoan.TenTK.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.thongbao = "Tên đăng nhập Hoặc Mật Khẩu sai";
            }
            return View();
        }
    }
}