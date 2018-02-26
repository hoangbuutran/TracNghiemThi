using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class LoaiNguoiDungController : LoginAdminController
    {
        // GET: Admin/LoaiNguoiDung
        TestDbContext db = null;
        public LoaiNguoiDungController()
        {
            db = new TestDbContext();
        }

        public ActionResult Index()
        {
            var model = new LoaiNguoiDungDao().toList();
            return View(model);
        }

        // GET: Admin/LoaiNguoiDung/Details/5
        public ActionResult Details(int id)
        {
            var model = new LoaiNguoiDungDao().NGUOIDUNGSINGLE(id);
            return View(model);
        }

        // GET: Admin/LoaiNguoiDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiNguoiDung/Create
        [HttpPost]
        public ActionResult Create(LOAINGUOIDUNG model, FormCollection collection)
        {
            LoaiNguoiDungDao dao = new LoaiNguoiDungDao();
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                if (model.TRANGTHAI != null)
                {
                    var ketqua = dao.ThemLoaiNguoiDung(model);
                    if (ketqua == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên loại người dùng đã tồn tại");
                        return View("Create");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mời nhập thông tin đầy đũ");
                    return View("Create");
                }
            }
            else
            {
                ModelState.AddModelError("", "Mời nhập thông tin đầy đũ");
                return View("Create");
            }
            return RedirectToAction("Index");
        }


        // GET: Admin/LoaiNguoiDung/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new LoaiNguoiDungDao().NGUOIDUNGSINGLE(id);
            return View(model);
        }

        // POST: Admin/LoaiNguoiDung/Edit/5
        [HttpPost]
        public ActionResult Edit(LOAINGUOIDUNG model)
        {
            LoaiNguoiDungDao dao = new LoaiNguoiDungDao();
            if (ModelState.IsValid)
            {
                var ketqua = dao.SuaLoaiNguoiDung(model);
                if (ketqua == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên loại người dùng đã tồn tại");
                    return RedirectToAction("Edit", new { id = model.IDLOAINGUOIDUNG });
                }

            }
            else
            {
                ModelState.AddModelError("", "Mời nhập thông tin đầy đũ");
                return RedirectToAction("Edit", new { id = model.IDLOAINGUOIDUNG });
            }
            return View("Index");
        }

        // GET: Admin/LoaiNguoiDung/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new LoaiNguoiDungDao().NGUOIDUNGSINGLE(id);
            return View(model);
        }

        // POST: Admin/LoaiNguoiDung/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            LoaiNguoiDungDao dao = new LoaiNguoiDungDao();

            var ketqua = dao.XoaLoaiNguoiDung(id);
            if (ketqua == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "loi error");
            }
            return RedirectToAction("Index");

        }
    }
}
