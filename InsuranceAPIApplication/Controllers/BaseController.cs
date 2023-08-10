using InsuranceAPIApplication.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace InsuranceAPIApplication.Controllers
{
    public class BaseController : Controller
    {
       protected User currentUser { get; private set; }

       protected override void OnActionExecuting(ActionExecutingContext filterContext)
       {
            currentUser = Session["CurrentUser"] as User;

            if(currentUser == null)
            {
                if (!filterContext.HttpContext.Request.IsAuthenticated)
                {
                    return;
                }
            }
        }
    }
}