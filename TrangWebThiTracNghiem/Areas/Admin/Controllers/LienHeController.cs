using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class LienHeController : LoginAdminController
    {
        private TestDbContext db = null;

        public LienHeController()
        {
            db = new TestDbContext();
        }

        // GET: Admin/LienHe
        public ActionResult Index()
        {
            return View(db.LIENHEs.ToList());
        }

        // GET: Admin/LienHe/Details/5
        public ActionResult Details(int id)
        {
            return View(db.LIENHEs.Find(id));
        }

        
        // GET: Admin/LienHe/Edit/5
        public ActionResult ThayDoiTrangThai(int id)
        {
            return View(db.LIENHEs.Find(id));
        }

        // POST: Admin/LienHe/Edit/5
        [HttpPost]
        public ActionResult ThayDoiTrangThai(LIENHE model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var ketqua = new LienHeDao().ThayDoiLienHe(model);
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

        // GET: Admin/LienHe/Delete/5
        public ActionResult Delete(int id)
        {
            var ketqua = new LienHeDao().XoaLienHe(id);
            if (!ketqua)
                ModelState.AddModelError("", "loi");
            else
                return RedirectToAction("Index");
            return View("Index");
        }
    }
}
