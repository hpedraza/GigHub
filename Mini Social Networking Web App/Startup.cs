using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mini_Social_Networking_Web_App.Startup))]
namespace Mini_Social_Networking_Web_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
