using System;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TrangWebThiTracNghiem.Controllers
{
    public class LienHeClientController : Controller
    {
        private TestDbContext db = null;

        public LienHeClientController()
        {
            db = new TestDbContext();
        }
        // GET: LienHe/Create
        public ActionResult Create()
        {
            var dethilist = new DeThiDao().ListDeThiMoi();
            ViewBag.dethilist = dethilist;
            return View();
        }

        // POST: LienHe/Create
        [HttpPost]
        public ActionResult Create(LIENHE model, FormCollection collection)
        {
            
                model.TRANGTHAI = false;
                model.NGAYGUIYKIEN = DateTime.Now;
                if (ModelState.IsValid)
                {
                    var dao = new LienHeDao().ThemLienHe(model);
                    if (dao)
                    {
                        return RedirectToAction("Index", "TrangChu");
                    }
                    else
                    {
                        return View("Error_404");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Thiếu thông tin");
                }
            return RedirectToAction("Create");
        }
    }
}
