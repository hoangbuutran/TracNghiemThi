using System.Web.Mvc;
using System.Web.Security;
using Model.Dao;
using Model.EF;
using TrangWebThiTracNghiem.Areas.Admin.Models;
using TrangWebThiTracNghiem.Common;
using TrangWebThiTracNghiem.Models;

namespace TrangWebThiTracNghiem.Controllers
{
    public class NguoiDungClientController : Controller
    {
        private TestDbContext db = null;

        public NguoiDungClientController()
        {
            db = new TestDbContext();
        }
        // GET: NguoiDungClient
        [HttpGet]
        public ActionResult Index()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginClientModel model)
        {
            var dao = new NguoiDungDao();
            var ketquadangnhap = dao.LoginClient(model.tenDangNhap, model.matKhau);
            if (ModelState.IsValid)
            {
                if (ketquadangnhap)
                {
                    var nguoidung = dao.getByMaNguoiDung(model.tenDangNhap);
                    var nguoidungSession = new NguoiDungLogin();
                    nguoidungSession.tendangnhap = nguoidung.TENDANGNHAP;
                    nguoidungSession.idnguoidung = nguoidung.IDNGUOIDUNG;
                    Session.Add(CommonConstant.USER_SESSION, nguoidungSession);
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn cần nhập thông tin đầy đủ");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "TrangChu");
        }

        [HttpGet]
        public ActionResult Creates()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View();
        }

        // POST: NguoiDungClient/Edit/5
        [HttpPost]
        public ActionResult Creates(NGUOIDUNG model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var ketqua = new NguoiDungDao().ThemNguoiDung(model);
                    if (ketqua)
                    {
                        var timlai = db.NGUOIDUNGs.Find(model.IDNGUOIDUNG);
                        timlai.TRANGTHAI = true;
                        timlai.DOTINCAY = 100;
                        db.SaveChanges();
                        var dao = new NguoiDungDao();
                        var ketquadangnhap = dao.LoginClient(model.TENDANGNHAP, model.MATKHAU);
                        if (ketquadangnhap)
                        {
                            var nguoidungsession = new NguoiDungLogin();
                            nguoidungsession.idnguoidung = model.IDNGUOIDUNG;
                            nguoidungsession.tendangnhap = model.TENDANGNHAP;
                            Session.Add(CommonConstant.USER_SESSION, nguoidungsession);
                            return RedirectToAction("Index", "TrangChu");
                        }
                    }
                    else
                    {
                        return View("Error_404");
                    }

                }
            }
            catch
            {
                return View("Error_404");
            }
            return View("Index");
        }


        // GET: NguoiDungClient/Details/5
        public ActionResult Details(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View(db.NGUOIDUNGs.Find(id));
        }

        // GET: NguoiDungClient/Edit/5
        public ActionResult Edit(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View(db.NGUOIDUNGs.Find(id));
        }

        // POST: NguoiDungClient/Edit/5
        [HttpPost]
        public ActionResult Edit(NGUOIDUNG model, FormCollection collection)
        {
            if (!ModelState.IsValid) return View("Edit");
            var dao = new NguoiDungDao();
            var ketqua = dao.SuaNguoiDung(model);
            if (ketqua)
            {
                return RedirectToAction("Details", new { id = model.IDNGUOIDUNG });
            }
            else
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Edit");
        }

        // GET: NguoiDungClient/Delete/5
        public ActionResult LichSuThi(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var dao = new BaiLamDao().toListLichSuThi(id);
            ViewBag.ds = dao;
            return View();
        }


        [HttpGet]
        public ActionResult DoiMatKhauClient(int id)
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            ViewBag.nguoidung = db.NGUOIDUNGs.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhauClient(DoiMKModel model)
        {
            if (ModelState.IsValid)
            {
                var session = (NguoiDungLogin)Session[CommonConstant.USER_SESSION];
                var nguoidung = db.NGUOIDUNGs.Find(session.idnguoidung);
                if (nguoidung.MATKHAU.Trim() == model.matKhauCu.Trim())
                {
                    var dao = new NguoiDungDao();
                    dao.DoiMatKhau(model.matKhauMoi, nguoidung);
                    return RedirectToAction("Details", "NguoiDungClient");
                }
                else
                {
                    return RedirectToAction("DoiMatKhauClient", "NguoiDungClient");
                }
            }
            return View("DoiMatKhauClient");
        }

    }
}
