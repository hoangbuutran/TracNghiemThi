using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrangWebThiTracNghiem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TaiLieuHocTap",
                url: "TaiLieuHocTap/{action}/{id}",
                defaults: new { controller = "TaiLieuHocTap", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "TinTucGiaoDuc",
                url: "TinTucGiaoDuc/{action}/{id}",
                defaults: new { controller = "TinTucGiaoDuc", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "LienHeClient",
                url: "LienHeClient/{action}/{id}",
                defaults: new { controller = "LienHeClient", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "NguoiDungClient",
                url: "NguoiDungClient/{action}/{id}",
                defaults: new { controller = "NguoiDungClient", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "ThongBaoClient",
                url: "ThongBao-Client/{action}/{id}",
                defaults: new { controller = "ThongBaoClient", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "Thi",
                url: "Thi/{action}/{id}",
                defaults: new { controller = "Thi", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TrangWebThiTracNghiem.Controllers" }
            );

        }
    }
}
