using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuthFromScratch.App_Start
{
    public class SecurityConfig
    {
        public static void Configure(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure google authentication
            var options = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "150027921711-a39u557afb292glf8i4b8ki6rk9sccro.apps.googleusercontent.com",
                ClientSecret = "B-okn_iwGMBggUS5pulQFTCq"
            };

            app.UseGoogleAuthentication(options);
        }
    }
}