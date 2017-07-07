using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mp_test.Startup))]
namespace mp_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
