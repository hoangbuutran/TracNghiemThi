using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;


namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class DeThiController : LoginAdminController
    {
        private readonly TestDbContext _db = null;
        public DeThiController()
        {
            _db = new TestDbContext();
        }

        // GET: Admin/DeThi
        public ActionResult Index()
        {
            return View(_db.DETHIs.ToList().OrderBy(x => x.IDMON));
        }

        // GET: Admin/DeThi/Details/5
        public ActionResult Details(int id)
        {
            var dao = new CT_CauHoi_DeThi();
            ViewBag.dsCauHoi = dao.ToListCauHoiDeThi(id);
            ViewBag.soCauDaCo = _db.CT_DETHI_CAUHOI.Count(x => x.IDDETHI == id);
            return View(_db.DETHIs.Find(id));
        }

        [HttpGet]
        public ActionResult ThemCauHoi(int id)
        {
            var dethi = _db.DETHIs.SingleOrDefault(x => x.IDDETHI == id);
            ViewBag.idDeThi = dethi.IDDETHI;
            ViewBag.tenDeThi = dethi.TENDETHI;
            var dao2 = _db.MONTHIs.Find(dethi.IDMON);
            ViewBag.Monthi = dao2;
            return View();
        }

        [HttpPost]
        public ActionResult ThemCauHoi(CT_DETHI_CAUHOI model)
        {
            var dao = new CauHoiDao();
            if (ModelState.IsValid)
            {
                //var ketqua = dao.ThemCauHoiTrungGian(model.CAUHOI, model.ID);
                //model.IDCAUHOI = ketqua.IDCAUHOI;
                var result = new CT_CauHoi_DeThi().ThemCT_CAUHOI_DeThi(model);
                if (result)
                {
                    return RedirectToAction("ThemCauHoi");
                }
            }
            else
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }



        // GET: Admin/DeThi/Create
        public ActionResult Create()
        {
            var dao = new MucDoDao();
            ViewBag.MucDoID = new SelectList(dao.toList(), "IDMUCDO", "TENMUCDO");
            var dao1 = new MonThiDao();
            ViewBag.MonThiID = new SelectList(dao1.toList(), "IDMON", "TENMON");
            var dao2 = new ThoiGianDao();
            ViewBag.ThoiGianID = new SelectList(dao2.toList(), "IDTHOIGIAN", "THOIGIAN1");
            var dao3 = new SoCauDao();
            ViewBag.SoCauID = new SelectList(dao3.toList(), "IDSOCAU", "SOCAU1");
            var dao4 = new CapThiDao();
            ViewBag.CapThiID = new SelectList(dao4.toList(), "IDCAPTHI", "TENCAPTHI");

            return View();
        }

        // POST: Admin/DeThi/Create
        [HttpPost]
        public ActionResult Create(DETHI model, FormCollection collection)
        {
            var dao = new DeThiDao();
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var ketqua = dao.ThemDeThi(model);
                if (!ketqua) return View("Index");
                return RedirectToAction("ThemCauHoi", new { id = model.IDDETHI });
            }
            else
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }

        // GET: Admin/DeThi/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new MucDoDao();
            ViewBag.MucDoID = new SelectList(dao.toList(), "IDMUCDO", "TENMUCDO");
            var dao1 = new MonThiDao();
            ViewBag.MonThiID = new SelectList(dao1.toList(), "IDMON", "TENMON");
            var dao2 = new ThoiGianDao();
            ViewBag.ThoiGianID = new SelectList(dao2.toList(), "IDTHOIGIAN", "THOIGIAN1");
            var dao3 = new SoCauDao();
            ViewBag.SoCauID = new SelectList(dao3.toList(), "IDSOCAU", "SOCAU1");
            ViewBag.soCauDaCo = _db.CT_DETHI_CAUHOI.Count(x => x.IDDETHI == id);
            var cauhoi = new CT_CauHoi_DeThi();
            ViewBag.dsCauHoi = cauhoi.ToListCauHoiDeThi(id);
            return View(_db.DETHIs.Find(id));
        }

        // POST: Admin/DeThi/Edit/5
        [HttpPost]
        public ActionResult Edit(DETHI model, FormCollection collection)
        {
            DeThiDao dao = new DeThiDao();

            var ketqua = dao.SuaDeThi(model);
            if (ketqua != 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "loi error");
            }
            return View("Index");
        }

        // GET: Admin/DeThi/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.DETHIs.Find(id));
        }

        // POST: Admin/DeThi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var dao = new DeThiDao();

            var ketqua = dao.XoaDeThi(id);
            if (ketqua != -1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "loi error");
                return View("Error_404");
            }
            return View("Index");
        }

        public ActionResult DetailsCauHoi(int id)
        {

            return View(_db.CAUHOIs.Find(id));
        }

        [HttpGet]
        public ActionResult ThemCauHoiDaCo(int id, int idDeThi)
        {
            var dao = new CauHoiDao();
            var dsCauHoi = dao.toListCauHoiMonThi(id, idDeThi);
            ViewBag.cauhoi = dsCauHoi;
            ViewBag.IDdethi = idDeThi;
            return View();
        }

        [HttpPost]
        public ActionResult ThemCauHoiDaCo(IList<CT_DETHI_CAUHOI> model)
        {
            int x = 0;
            int so = model.Count();
            for (int i = 0; i < so; i++)
            {
                if (model[i].ISSELECTED == true)
                {
                    var ketqua = new CT_CauHoi_DeThi().ThemCT_CAUHOI_DeThi(model[i]);
                }
                x = i;
            }
            return RedirectToAction("Details", "DeThi", new { id = model[x].IDDETHI });
        }

        public ActionResult XoaCauHoiTrongDe(int id)
        {
            var ketqua = new CT_CauHoi_DeThi().XoaCauHoiTrongDeDao(id);
            if (ketqua != 0)
            {
                return RedirectToAction("Edit", "DeThi", new { id = ketqua });
            }
            ModelState.AddModelError("", "Xoa cau hoi khong thanh cong");
            return View("Index");
        }
    }
}
