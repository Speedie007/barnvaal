using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RiccoTest2.Startup))]
namespace RiccoTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
