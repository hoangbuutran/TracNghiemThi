using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace TrangWebThiTracNghiem.Areas.Admin.Controllers
{
    public class HomeController : LoginAdminController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var daoSoNguoiDUng = new HomeDao().DemSoNguoiDung();
            ViewBag.SoNguoiDung = daoSoNguoiDUng;
            var daoSoDeThi = new HomeDao().DemSoDeThi();
            ViewBag.SoDeThi = daoSoDeThi;
            var daoSoCauHoi = new HomeDao().DemSoCauHoi();
            ViewBag.SoCauHoi = daoSoCauHoi;
            var daoSoTinTuc = new HomeDao().DemSoTinTuc();
            ViewBag.SoTinTuc = daoSoTinTuc;
            return View();
        }
    }
}