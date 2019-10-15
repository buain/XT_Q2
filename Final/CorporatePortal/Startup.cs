using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorporatePortal.Startup))]
namespace CorporatePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
