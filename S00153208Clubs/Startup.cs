using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S00153208Clubs.Startup))]
namespace S00153208Clubs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
