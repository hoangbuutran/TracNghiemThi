using System.Web.Mvc;
using System.Web.Security;
using Model.Dao;
using TrangWebThiTracNghiem.Areas.Admin.Models;
using TrangWebThiTracNghiem.Common;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            NguoiDungDao dao = new NguoiDungDao();
            var ketquadangnhap = dao.LoginAdmin(model.tenDangNhap, model.matKhau);
            if (ModelState.IsValid)
            {
                if (ketquadangnhap)
                {
                    var nguoidung = dao.getByMaNguoiDung(model.tenDangNhap);
                    var nguoidungSession = new NguoiDungLogin();
                    nguoidungSession.tendangnhap = nguoidung.TENDANGNHAP;
                    nguoidungSession.idnguoidung = nguoidung.IDNGUOIDUNG;
                    Session.Add(CommonConstant.USER_SESSION, nguoidungSession);
                    return RedirectToAction("Index", "Home");
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}