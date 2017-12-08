
using OAuthFromScratch.App_Start;
using Owin;

namespace OAuthFromScratch
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //SecurityConfig.Configure(app);
            WebApiConfig.Configure(app);
        }
    }
}