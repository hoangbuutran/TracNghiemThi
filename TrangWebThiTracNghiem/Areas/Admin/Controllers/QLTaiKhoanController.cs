using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using TrangWebThiTracNghiem.Areas.Admin.Models;


namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class QLTaiKhoanController : LoginAdminController
    {
        private TestDbContext db = null;

        public QLTaiKhoanController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/QLTaiKhoan
        public ActionResult XemThongTinTaiKhoan()
        {
            var session = (Common.NguoiDungLogin)Session[Common.CommonConstant.USER_SESSION];
            return View(db.NGUOIDUNGs.Find(session.idnguoidung));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var session = (MoWebBayBa.Common.NguoiDungLogin)Session[MoWebBayBa.Common.CommonConstant.USER_SESSION];
            return View(db.NGUOIDUNGs.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(NGUOIDUNG model)
        {
            if (!ModelState.IsValid) return View("XemThongTinTaiKhoan");
            var dao = new NguoiDungDao();
            var ketqua = dao.SuaNguoiDung(model);
            if (!ketqua)
                ModelState.AddModelError("", "Loi error");
            else
                return RedirectToAction("XemThongTinTaiKhoan", "QLTaiKhoan");
            return View("XemThongTinTaiKhoan");
        }

        [HttpGet]
        public ActionResult DoiMatKhau(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(DoiMKModel model)
        {
            if (ModelState.IsValid)
            {
                var session = (Common.NguoiDungLogin)Session[Common.CommonConstant.USER_SESSION];
                var nguoidung = db.NGUOIDUNGs.Find(session.idnguoidung);
                if (nguoidung.MATKHAU.Trim() == model.matKhauCu.Trim())
                {
                    var dao = new NguoiDungDao();
                    dao.DoiMatKhau(model.matKhauMoi, nguoidung);
                    return RedirectToAction("XemThongTinTaiKhoan", "QLTaiKhoan");
                }
                else
                {
                    return RedirectToAction("DoiMatKhau", "QLTaiKhoan");
                }
            }
            return View("DoiMatKhau");
        }
    }
}