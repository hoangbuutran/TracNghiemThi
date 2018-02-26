using System.Web.Mvc;
using Model.Dao;

namespace TrangWebThiTracNghiem.Controllers
{
    public class ThongBaoClientController : Controller
    {
        // GET: ThongBaoClient
        public ActionResult Index()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            var thongbao = new ThongBaoDao();
            ViewBag.ListThongBao = thongbao.toList();
            return View();
        }

    }
}