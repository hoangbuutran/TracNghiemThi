using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class ThiController : BaseClientController
    {

        TestDbContext db = null;
        public ThiController()
        {
            db = new TestDbContext();
        }
        // GET: Thi
        [HttpGet]
        public ActionResult Index(int iddethi, int idbailam)
        {
            var dao = new CT_CauHoi_DeThi();
            var dsCauHoi = dao.toListCauHoi(iddethi);
            int soCauHoiCo = dao.soCauHoiDangCo(iddethi);
            ViewBag.cauhoi = dsCauHoi;
            ViewBag.soCauHoi = soCauHoiCo;
            ViewBag.idBaiLam = idbailam;

            var thongtin = new BaiLamDao().getBaiLamSingle(idbailam);

            ViewBag.thongtin = thongtin;

            return View();
        }

        [HttpPost]
        public ActionResult Index(IList<CT_BAIlAM_CAUHOI> model, FormCollection collection)
        {
            int x = 0;
            if (ModelState.IsValid)
            {
                int so = model.Count();
                for (int i = 0; i < so; i++)
                {
                    var ketqua = new CT_BaiLam_CauHoi().ThemCT_BAIlAM_CAUHOI(model[i]);
                    x = i;
                }
                return RedirectToAction("Details", "BaiLam", new { id = model[x].IDBAILAM });

            }
            return View("Error_404");
        }
    }
}