using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MEGA.Startup))]
namespace MEGA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
