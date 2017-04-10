using CameraBazaar.Data;
using CameraBazaar.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CameraBazaar
{
    public class IdentiyConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new CameraBazaarContext());
            app.CreatePerOwinContext<RoleManager<Role>>((options, context) =>
                new RoleManager<Role>(
                    new RoleStore<Role>(context.Get<CameraBazaarContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}