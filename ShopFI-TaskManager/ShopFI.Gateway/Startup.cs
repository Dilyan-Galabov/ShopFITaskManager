using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopFI.Gateway.Startup))]
namespace ShopFI.Gateway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
