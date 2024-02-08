using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContosoSite.Startup))]
namespace ContosoSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}