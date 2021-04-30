using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lagerverwaltung.Web.Startup))]
namespace Lagerverwaltung.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
