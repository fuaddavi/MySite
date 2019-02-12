using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewWebApplication.Startup))]
namespace NewWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
