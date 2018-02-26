using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class TinTucController : LoginAdminController
    {
        private TestDbContext _db = null;
        public TinTucController()
        {
            _db = new TestDbContext();
        }
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            return View(_db.TINTUCs.ToList());
        }

        // GET: Admin/TinTuc/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.TINTUCs.Find(id));
        }

        // GET: Admin/TinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinTuc/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TINTUC model, FormCollection collection)
        {
            try
            {
                var dao = new TinTucDao().ThemTinTuc(model);
                if (dao)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Index");
            }
            return View("Index");
        }

        // GET: Admin/TinTuc/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new TinTucDao().SingleTinTucID(id);
            return View(model);
        }

        // POST: Admin/TinTuc/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TINTUC model, FormCollection collection)
        {
            try
            {
                var dao = new TinTucDao().SuaTinTuc(model);
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

        // GET: Admin/TinTuc/Delete/5
        public ActionResult Delete(int id)
        {
            var dao = new TinTucDao().XoaTinTuc(id);
            if (dao)
            {
                return RedirectToAction("Index", "TinTuc");
            }
            return View("Error_404");
        }

        
    }
}
