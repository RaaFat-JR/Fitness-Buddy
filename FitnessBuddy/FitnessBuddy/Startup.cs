using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessBuddy.Startup))]
namespace FitnessBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
