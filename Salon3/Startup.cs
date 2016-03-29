using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Salon3.Startup))]
namespace Salon3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
