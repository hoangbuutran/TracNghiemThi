using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class CapThiController : LoginAdminController
    {

        TestDbContext db = null;
        public CapThiController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/CapThi
        public ActionResult Index()
        {
            var model = new CapThiDao().toList();
            return View(model);
        }

        // GET: Admin/CapThi/Details/5
        public ActionResult Details(int id)
        {
            var model = new CapThiDao().CapThiSingle(id);
            return View(model);
        }

        // GET: Admin/CapThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CapThi/Create
        [HttpPost]
        public ActionResult Create(CAPTHI model, FormCollection collection)
        {
            var ketqua = new CapThiDao().ThemCapThi(model);
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                if (ketqua == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên cấp thi đã tồn tại");
                    return View("Create");
                }
            }
            else
            {
                ModelState.AddModelError("", "Điền đầy đủ thông tin");
                return View("Create");
            }
            return View("Index");

        }

        // GET: Admin/CapThi/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CapThiDao().CapThiSingle(id);
            return View(model);
        }

        // POST: Admin/CapThi/Edit/5
        [HttpPost]
        public ActionResult Edit(CAPTHI model, FormCollection collection)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    var ketqua = new CapThiDao().SuaCapThi(model);
                    if (ketqua == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên cấp thi đã tồn tại");
                        return RedirectToAction("Edit", new { id = model.IDCAPTHI });
                    }
                }
            //}
            //catch
            //{
            //    return View("Error_404");
            //}
            return View("Index");
        }

        // GET: Admin/CapThi/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new CapThiDao().CapThiSingle(id);
            return View(model);
        }

        // POST: Admin/CapThi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var ketqua = new CapThiDao().XoaCapThi(id);
                if (ketqua == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tồn tại môn thi, đề thi, chuyên ngành thuộc cấp thi này.");
                    return RedirectToAction("Edit", new { id = id});
                }
            }
            catch
            {
                return View("Error_404");
            }
            return RedirectToAction("Index");
        }
    }
}
