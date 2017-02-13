using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iscore.WebSite.Startup))]
namespace Iscore.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
