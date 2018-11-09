using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFUI.Startup))]
namespace EFUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
