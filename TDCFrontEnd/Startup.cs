using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDCFrontEnd.Startup))]
namespace TDCFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
