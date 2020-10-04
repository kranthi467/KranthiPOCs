using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OAuthMVC.Startup))]
namespace OAuthMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
