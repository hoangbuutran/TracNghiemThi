using System;
using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class NguoiDungController : LoginAdminController
    {
        TestDbContext db = null;
        public NguoiDungController()
        {
            db = new TestDbContext();
        }
        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            return View(db.NGUOIDUNGs.ToList());
        }

        // GET: Admin/NguoiDung/Details/5
        public ActionResult Details(int id)
        {
            return View(db.NGUOIDUNGs.Find(id));
        }

        // GET: Admin/NguoiDung/Create
        public ActionResult Create()
        {
            var dao = new LoaiNguoiDungDao();
            ViewBag.LoaiNguoiDungID = new SelectList(dao.toList(), "IDLOAINGUOIDUNG", "TENLOAINGUOIDUNG");
            return View();
        }

        // POST: Admin/NguoiDung/Create
        [HttpPost]
        public ActionResult Create(NGUOIDUNG model, FormCollection collection)
        {
            NguoiDungDao dao = new NguoiDungDao();
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var ketqua = dao.ThemNguoiDung(model);
                if (ketqua)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }

        // GET: Admin/NguoiDung/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new LoaiNguoiDungDao();
            ViewBag.LoaiNguoiDungID = new SelectList(dao.toList(), "IDLOAINGUOIDUNG", "TENLOAINGUOIDUNG");
            return View(db.NGUOIDUNGs.Find(id));
        }

        // POST: Admin/NguoiDung/Edit/5
        [HttpPost]
        public ActionResult Edit(NGUOIDUNG model)
        {
            if (!ModelState.IsValid) return View("Index");
            var dao = new NguoiDungDao();
            var ketqua = dao.PhanQuyenVaKhoa(model);
            if (!ketqua)
                ModelState.AddModelError("", "Loi error");
            else
                return RedirectToAction("Index", "NguoiDung");
            return View("Index");
        }

        // GET: Admin/NguoiDung/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.NGUOIDUNGs.Find(id));
        }

        // POST: Admin/NguoiDung/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dao = new NguoiDungDao();

                var ketqua = dao.XoaNguoiDung(id);
                if (!ketqua)
                    ModelState.AddModelError("", "Loi error");
                else
                    return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            return View("Index");
        }
    }
}
