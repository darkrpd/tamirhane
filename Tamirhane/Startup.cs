using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamirhane.Startup))]
namespace Tamirhane
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
