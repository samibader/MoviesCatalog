using MoviesCatalog.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesCatalog.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.PosterFolder = "~/MoviePosters/";
            base.OnActionExecuting(filterContext);
        }

    }
}