using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class TaiLieuHocTapController : Controller
    {
        TestDbContext db = null;
        public TaiLieuHocTapController()
        {
            db = new TestDbContext();
        }
        // GET: TaiLieuHocTap
        public ActionResult Index()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var monthi = new MonThiDao().toList();
            ViewBag.monthi = monthi;
            var capthi = new CapThiDao().toList();
            ViewBag.capthi = capthi;
            var chuyennganh = new ChuyenNganhDao();
            ViewBag.chuyennganh = chuyennganh.toList();
            var ct_chuyennganh = new CT_ChuyenNganh_MonDao();
            ViewBag.CT_chuyennganh = ct_chuyennganh.ToList();
            return View(db.TAILIEUx.ToList());
        }

        public ActionResult HienThiDsBaiThi(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View(db.TAILIEUx.Where(x=>x.IDMON == id).ToList());
        }

        public ActionResult XemChiTiet(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View(db.TAILIEUx.Find(id));
        }

    }
}