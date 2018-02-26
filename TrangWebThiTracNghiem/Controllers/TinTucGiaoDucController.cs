using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class TinTucGiaoDucController : Controller
    {
        private TestDbContext db = null;

        public TinTucGiaoDucController()
        {
            db = new TestDbContext();
        }
        // GET: TinTucGiaoDuc
        public ActionResult Index()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View(db.TINTUCs.ToList());
        }

        public ActionResult xemtin(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var tintuc = new TinTucDao();
            ViewBag.tintuc = tintuc.listtintucsapxep();
            return View(db.TINTUCs.Find(id));
        }
        


    }
}