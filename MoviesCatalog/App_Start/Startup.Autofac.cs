﻿using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using MoviesCatalog.Attributes;
using MoviesCatalog.Data.Access.Autofac;
using MoviesCatalog.Service.Autofac;
using Owin;

namespace MoviesCatalog
{
    public partial class Startup
    {
        public void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DataLayer());
            builder.RegisterModule(new ServiceLayer());

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.Register(c => new AuthorizedToEditAndDelete()).InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}