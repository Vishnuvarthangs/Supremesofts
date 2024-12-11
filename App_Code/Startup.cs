using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupremeSoft.Startup))]
namespace SupremeSoft
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
