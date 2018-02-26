using System;
using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class ThongBaoController : LoginAdminController
    {
        private TestDbContext db = null;


        public ThongBaoController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/ThongBao
        public ActionResult Index()
        {
            return View(db.THONGBAOs.ToList());
        }

        // GET: Admin/ThongBao/Details/5
        public ActionResult Details(int id)
        {
            return View(db.THONGBAOs.Find(id));
        }


        [HttpGet]
        // GET: Admin/ThongBao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThongBao/Create
        [HttpPost]
        public ActionResult Create(THONGBAO model, FormCollection collection)
        {
            try
            {
                model.TRANGTHAI = true;
                model.NGAYDANG = DateTime.Now;
                var ketqua = new ThongBaoDao().ThemThongBao(model);
                if (ketqua)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Không thể tạo mới thông báo");
                return View();
            }
            return View("Index");
        }

        [HttpGet]
        // GET: Admin/ThongBao/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.THONGBAOs.Find(id));
        }

        // POST: Admin/ThongBao/Edit/5
        [HttpPost]
        public ActionResult Edit(THONGBAO model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var ketqua = new ThongBaoDao().SuaThongBao(model);
                if (ketqua == 0)
                    ModelState.AddModelError("", "loi");
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View("Index");
        }

        // GET: Admin/ThongBao/Delete/5
        public ActionResult Delete(int id)
        {
            var ketqua = new ThongBaoDao().XoaThongBao(id);
            if (!ketqua)
                ModelState.AddModelError("", "loi");
            else
                return RedirectToAction("Index");
            return View("Index");
        }

        // POST: Admin/ThongBao/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
