using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class CauHoiController : LoginAdminController
    {
        TestDbContext db = null;
        public CauHoiController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/CauHoi
        public ActionResult Index()
        {
            var model = new CauHoiDao().ListcauhoiInDb();
            return View(model);
        }

        // GET: Admin/CauHoi/Details/5
        public ActionResult Details(int id)
        {
            var model = new CauHoiDao().cauhoisingle(id);
            return View(model);
        }

        // GET: Admin/CauHoi/Create
        public ActionResult Create()
        {
            var daoMonThi = new MonThiDao();
            ViewBag.MonThiID = new SelectList(daoMonThi.toList(), "IDMON", "TENMON");
            return View();
        }

        // POST: Admin/CauHoi/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CAUHOI model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new CauHoiDao().ThemCauHoi(model);
                    if (dao == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        ModelState.AddModelError("", "không thể thêm dữ liệu");
                        return View("Create");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Điền thông tin đầy đủ");
                    return View("Create");
                }
            }
            catch
            {
                return View("Error_404");
            }
            //return View("Index");
        }

        // GET: Admin/CauHoi/Edit/5
        public ActionResult Edit(int id)
        {
            //var dao = db.CAUHOIs.Find(id);
            //var dao2 = db.MONTHIs.Find(dao.IDMON);
            //ViewBag.Monthi = dao2;
            var model = new CauHoiDao().cauhoisingle(id);
            var dao2 = db.MONTHIs.Find(model.IDMON);
            ViewBag.Monthi = dao2;
            return View(model);
        }

        // POST: Admin/CauHoi/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CAUHOI model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new CauHoiDao().SuaCauHoi(model);
                    if (dao == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Loi khong sua duoc du lieu");
                        return RedirectToAction("Edit", new { id = model.IDCAUHOI });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Dien day du thong tin");
                    return RedirectToAction("Edit", new { id = model.IDCAUHOI });
                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Index");
        }

        // GET: Admin/CauHoi/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new CauHoiDao().cauhoisingle(id);
            return View(model);
        }

        // POST: Admin/CauHoi/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dao = new CauHoiDao().XoaCauHoi(id);
                if (dao != -1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Khong the xoa");
                    return RedirectToAction("Delete", new { id = id});
                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Index");
        }
    }
}
