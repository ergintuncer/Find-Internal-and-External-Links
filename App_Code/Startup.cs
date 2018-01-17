using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindLinks.Startup))]
namespace FindLinks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
