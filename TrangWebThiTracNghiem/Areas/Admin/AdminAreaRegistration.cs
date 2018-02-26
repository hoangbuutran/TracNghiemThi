using System.Web.Mvc;

namespace TrangWebThiTracNghiem.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "TinTuc",
                "Admin/TinTuc/{action}/{id}",
                new { action = "Index", controller = "TinTuc", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "TaiLieu",
                "Admin/TaiLieu/{action}/{id}",
                new { action = "Index", controller = "TaiLieu", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "LienHe",
                "Admin/LienHe/{action}/{id}",
                new { action = "Index", controller = "LienHe", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "MonThi",
                "Admin/MonThi/{action}/{id}",
                new { action = "Index", controller = "MonThi", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "CauHoi",
                "Admin/CauHoi/{action}/{id}",
                new { action = "Index", controller = "CauHoi", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "DeThi",
                "Admin/DeThi/{action}/{id}",
                new { action = "Index", controller = "DeThi", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "CapThi",
                "Admin/CapThi/{action}/{id}",
                new { action = "Index", controller = "CapThi", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "LoaiNguoiDung",
                "Admin/LoaiNguoiDung/{action}/{id}",
                new { action = "Index", controller = "LoaiNguoiDung", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "NguoiDung",
                "Admin/NguoiDung/{action}/{id}",
                new { action = "Index", controller = "NguoiDung", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}