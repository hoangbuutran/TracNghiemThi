using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class TrangChuController : Controller
    {
        private TestDbContext db = null;

        public TrangChuController()
        {
            db = new TestDbContext();
        }
        public ActionResult Index()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var dao = new ShowGiaoDienChinhDao();
            ViewBag.MenuChinh = dao.ListCapThi();
            ViewBag.MenuCon = dao.ListMonThi();
            var thongbao = new ThongBaoDao();
            ViewBag.ListThongBao = thongbao.toList();
            var socau = new SoCauDao();
            ViewBag.socau = socau.toList();
            var thoigian = new ThoiGianDao();
            ViewBag.thoigian = thoigian.toList();
            var chuyennganh = new ChuyenNganhDao();
            ViewBag.chuyennganh = chuyennganh.toList();
            var dethi = new DeThiDao();
            ViewBag.dethi = dethi.toList();
            var dao0 = new MucDoDao();
            ViewBag.MucDoID = new SelectList(dao0.toList(), "IDMUCDO", "TENMUCDO");
            var dao1 = new MonThiDao();
            ViewBag.MonThiID = new SelectList(dao1.toList(), "IDMON", "TENMON");
            var dao2 = new ThoiGianDao();
            ViewBag.ThoiGianID = new SelectList(dao2.toList(), "IDTHOIGIAN", "THOIGIAN1");
            var dao3 = new SoCauDao();
            ViewBag.SoCauID = new SelectList(dao3.toList(), "IDSOCAU", "SOCAU1");
            var dao4 = new CapThiDao();
            ViewBag.CapThiID = new SelectList(dao4.toList(), "IDCAPTHI", "TENCAPTHI");

            var tintuc = new TinTucDao();
            ViewBag.tintuc = tintuc.listtintucsapxep();
            ViewBag.tintuctop = tintuc.tintuctop1();

            return View();
        }

        [HttpGet]
        public ActionResult DSDeThi(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var DeThi = new DeThiDao().toListDeThiID(id);
            ViewBag.dethi = DeThi;
            ViewBag.monthi = db.MONTHIs.Find(id);
            return View(ViewBag.dethi);
        }

        [HttpGet]
        public ActionResult DSDeThiCNDH(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var Monthi = new ChuyenNganhDao().toListCNDH(id);
            ViewBag.monthi = Monthi;
            var dethi = new DeThiDao();
            ViewBag.dethi = dethi.toList();
            return View();
        }
        [HttpGet]
        public ActionResult XemDeThi(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var dao = new CT_CauHoi_DeThi();
            ViewBag.dsCauHoi = dao.ToListCauHoiDeThi(id);
            ViewBag.soCauDaCo = db.CT_DETHI_CAUHOI.Count(x => x.IDDETHI == id);
            return View(db.DETHIs.Find(id));
        }

        //[HttpGet]
        //public ActionResult ChiTietCauHoi(int id)
        //{
        //    var dethilist = new DeThiDao().ListDeThiMoi();
        //    ViewBag.dethilist = dethilist;
        //    ViewBag.cauHoi = db.CAUHOIs.Find(id);
        //    return View();
        //}
    }
}