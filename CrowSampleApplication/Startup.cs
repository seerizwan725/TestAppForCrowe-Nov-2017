using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrowSampleApplication.Startup))]
namespace CrowSampleApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
