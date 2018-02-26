using System.Web.Mvc;
using System.Web.Routing;
using TrangWebThiTracNghiem.Common;

namespace TrangWebThiTracNghiem.Controllers
{
    public class BaseClientController : Controller
    {
        // GET: BaseClient
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (NguoiDungLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "NguoiDungClient", action = "Index" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}