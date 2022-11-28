using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_DSM.Startup))]
namespace Web_DSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
