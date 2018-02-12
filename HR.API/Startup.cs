using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HR.API.Startup))]

namespace HR.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}