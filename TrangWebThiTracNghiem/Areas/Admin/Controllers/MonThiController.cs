using System;
using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class MonThiController : LoginAdminController
    {

        TestDbContext db = null;
        public MonThiController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/MonThi
        public ActionResult Index()
        {
            return View(db.MONTHIs.ToList().OrderBy(x=>x.IDCAPTHI));
        }

        // GET: Admin/MonThi/Details/5
        public ActionResult Details(int id)
        {
            return View(db.MONTHIs.Find(id));
        }

        // GET: Admin/MonThi/Create
        public ActionResult Create()
        {
            var dao = new CapThiDao();
            ViewBag.CapThiID = new SelectList(dao.toList(), "IDCAPTHI", "TENCAPTHI");
            return View();
        }

        // POST: Admin/MonThi/Create
        [HttpPost]
        public ActionResult Create(MONTHI model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ketqua = new MonThiDao().ThemMonThi(model);
                    if (ketqua)
                    {
                        var timten = db.MONTHIs.Find(model.IDMON);
                        if (timten != null) timten.TENMON = timten.TENMON + " " + timten.CAPTHI.TENCAPTHI;
                        db.SaveChanges();
                        if (model.IDCAPTHI == 12)
                        {
                            return RedirectToAction("ThemMonChuyenNganh", "ChuyenNganh", new { id = timten.IDMON });
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Loi error");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View("Index");
        }

        // GET: Admin/MonThi/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new CapThiDao();
            ViewBag.CapThiID = new SelectList(dao.toList(), "IDCAPTHI", "TENCAPTHI");
            return View(db.MONTHIs.Find(id));
        }

        // POST: Admin/MonThi/Edit/5
        [HttpPost]
        public ActionResult Edit(MONTHI model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var dao = new MonThiDao().SuaMonThi(model);
                if (dao != 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "loi error");
                }

            }
            catch
            {
                return View();
            }
            return View("Index");
        }

        // GET: Admin/MonThi/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.MONTHIs.Find(id));
        }

        // POST: Admin/MonThi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MonThiDao dao = new MonThiDao();

                var ketqua = dao.XoaMOnThi(id);
                if (ketqua)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Loi error");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            return View("Index");
        }
    }
}
