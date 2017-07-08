using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetzGST.Startup))]
namespace LetzGST
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
