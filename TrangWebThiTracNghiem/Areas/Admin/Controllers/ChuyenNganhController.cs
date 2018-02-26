using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class ChuyenNganhController : LoginAdminController
    {
        private TestDbContext db = null;

        public ChuyenNganhController()
        {
            db = new TestDbContext();
        }
        // GET: Admin/ChuyenNganh
        public ActionResult Index()
        {
            return View(db.CHUYENNGANH_DH.ToList());
        }

        // GET: Admin/ChuyenNganh/Details/5
        public ActionResult Details(int id)
        {
            return View(db.CHUYENNGANH_DH.Find(id));
        }

        // GET: Admin/ChuyenNganh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChuyenNganh/Create
        [HttpPost]
        public ActionResult Create(CHUYENNGANH_DH model, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuyenNganhDao().ThemMoiChuyenNganh(model);
                if (dao)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Create", "ChuyenNganh");
                }
            }
            return View("Index");
        }

        // GET: Admin/ChuyenNganh/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.CHUYENNGANH_DH.Find(id));
        }

        // POST: Admin/ChuyenNganh/Edit/5
        [HttpPost]
        public ActionResult Edit(CHUYENNGANH_DH model, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuyenNganhDao().SuaChuyenNganh(model);
                if (dao)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit", "ChuyenNganh");
                }
            }
            return View("Index");
        }

        // GET: Admin/ChuyenNganh/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.CHUYENNGANH_DH.Find(id));
        }

        // POST: Admin/ChuyenNganh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var  dao = new ChuyenNganhDao();
            var ketqua = dao.XoaChuyenNganh(id);
            if (ketqua)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete", "ChuyenNganh");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult ThemMonChuyenNganh(int id)
        {
            ViewBag.monthi = db.MONTHIs.Find(id);
            var dao = new ChuyenNganhDao();
            ViewBag.chuyennganh = new SelectList(dao.toList(), "IDCN_DH", "TENCN_DH");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMonChuyenNganh(CT_CHUYENNGANH_MON model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChuyenNganhDao().them_CTChuyenNganhMon(model);
                return RedirectToAction("Index", "MonThi");
            }
            return View("Index");
        }

    }
}
