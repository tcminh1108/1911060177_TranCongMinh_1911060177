using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911060177_TranCongMinh_1911060177.Startup))]
namespace _1911060177_TranCongMinh_1911060177
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
