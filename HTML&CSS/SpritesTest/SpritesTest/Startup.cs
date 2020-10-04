using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpritesTest.Startup))]
namespace SpritesTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
