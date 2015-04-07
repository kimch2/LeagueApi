using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueApi.Startup))]
namespace LeagueApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
