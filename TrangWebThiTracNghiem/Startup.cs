using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrangWebThiTracNghiem.Startup))]
namespace TrangWebThiTracNghiem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
