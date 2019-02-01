using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesCatalog.Attributes
{
    public class AuthorizedToEditAndDelete : AuthorizeAttribute
    {
        
        public AuthorizedToEditAndDelete()
        {
            
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }

            var rd = httpContext.Request.RequestContext.RouteData;

            var id = rd.Values["id"];
            var userName = httpContext.User.Identity.Name;

            Movie movie = DependencyResolver.Current.GetService<IUnitOfWork>().Movies.GetById(int.Parse(id.ToString()));
            
            rd.Values["model"] = movie;

            return movie.User.UserName == userName;
        }
    }
}