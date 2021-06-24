using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dieting_Do.Startup))]
namespace Dieting_Do
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
