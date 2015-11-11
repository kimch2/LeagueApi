using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreTracker.Startup))]
namespace StoreTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
