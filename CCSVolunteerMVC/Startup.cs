using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCSVolunteerMVC.Startup))]
namespace CCSVolunteerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
