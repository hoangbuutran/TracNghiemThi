using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class TaiLieuController : LoginAdminController
    {
        private TestDbContext _db = null;
        public TaiLieuController()
        {
            _db = new TestDbContext();
        }
        // GET: Admin/TaiLieu
        public ActionResult Index()
        {
            var model = new TaiLieuDao().ToList();
            var monthi = new MonThiDao().toList();
            ViewBag.monthi = monthi;
            var capthi = new CapThiDao().toList();
            ViewBag.capthi = capthi;
            var chuyennganh = new ChuyenNganhDao();
            ViewBag.chuyennganh = chuyennganh.toList();
            var ct_chuyennganh = new CT_ChuyenNganh_MonDao();
            ViewBag.CT_chuyennganh = ct_chuyennganh.ToList();
            return View(model);
        }

        // GET: Admin/TaiLieu/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.TAILIEUx.Find(id));
        }

        // GET: Admin/TaiLieu/Create
        public ActionResult Create()
        {
            var dao = new MonThiDao();
            ViewBag.Monthi = new SelectList(dao.toList(), "IDMON", "TENMON");
            return View();
        }

        // POST: Admin/TaiLieu/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TAILIEU model, FormCollection collection)
        {
            try
            {
                var dao = new TaiLieuDao();
                if (dao.ThemThemTaiLieu(model))
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Index");
        }

        // GET: Admin/TaiLieu/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.TAILIEUx.Find(id));
        }

        // POST: Admin/TaiLieu/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TAILIEU model, FormCollection collection)
        {
            try
            {
                var dao = new TaiLieuDao().SuaTaiLieu(model);
                if (dao != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Index");
        }

        // GET: Admin/TaiLieu/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.TAILIEUx.Find(id));
        }

        // POST: Admin/TaiLieu/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dao = new TaiLieuDao().XoaTaiLieu(id);
                if (dao)
                {
                    return RedirectToAction("Index");
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
