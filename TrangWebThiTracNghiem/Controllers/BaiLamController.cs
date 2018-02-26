using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class BaiLamController : BaseClientController
    {

        private TestDbContext db = null;

        public BaiLamController()
        {
            db = new TestDbContext();
        }

        //GET: BaiLam/Create

        public ActionResult Create(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var dao = new DeThiDao();
            ViewBag.dethi = dao.getDeThiSingle(id);
            return View();
        }

        // POST: BaiLam/Create
        [HttpPost]
        public ActionResult Create(BAILAM model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var ketqua = new BaiLamDao().ThemBaiLam(model);
                if (ketqua)
                {
                    var timlai = db.BAILAMs.Find(model.IDBAILAM);
                    timlai.DIEM = 0;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Thi", new { iddethi = model.IDDETHI, idbailam = model.IDBAILAM });
                }
                else
                {
                    ModelState.AddModelError("", "loi");
                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Error_404");
        }


        // GET: BaiLam/Details/5
        public ActionResult Details(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            BAILAM timbailam = db.BAILAMs.Find(id);
            var dethi = db.CT_DETHI_CAUHOI.Where(x => x.IDDETHI == timbailam.IDDETHI).ToList();
            ViewBag.dscauhoi = dethi;
            int iddethi = timbailam.DETHI.IDDETHI;
            int idbailam = timbailam.IDBAILAM;
            var sosanh = new BaiLamDao();
            var tongDiemBaiThi = sosanh.SoSanhDapAn(iddethi, idbailam);
            timbailam.DIEM = tongDiemBaiThi;
            db.SaveChanges();
            return View(db.BAILAMs.Find(id));
        }

        [HttpGet]
        public ActionResult ChiTietCauHoidathi(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            ViewBag.cauHoi = db.CAUHOIs.Find(id);
            return View();
        }

    }
}
