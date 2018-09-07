using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EveryNationRandburg.Startup))]
namespace EveryNationRandburg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
