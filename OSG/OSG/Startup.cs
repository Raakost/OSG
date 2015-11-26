using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSG.Startup))]
namespace OSG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
