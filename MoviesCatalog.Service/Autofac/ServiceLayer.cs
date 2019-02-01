using Autofac;
using Microsoft.Owin.Security.DataProtection;
using MoviesCatalog.Data.Identity;
using MoviesCatalog.Service.Identity;

namespace MoviesCatalog.Service.Autofac
{
    public class ServiceLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => ApplicationUserManager.Create(c.Resolve<IUserStore>(), c.Resolve<IDataProtectionProvider>())).AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
        }
    }
}
