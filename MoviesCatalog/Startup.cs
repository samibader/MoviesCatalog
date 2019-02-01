using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesCatalog.Startup))]
namespace MoviesCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            ConfigureAuth(app);
        }
    }
}
