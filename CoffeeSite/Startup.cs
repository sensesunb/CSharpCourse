using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeSite.Startup))]
namespace CoffeeSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
