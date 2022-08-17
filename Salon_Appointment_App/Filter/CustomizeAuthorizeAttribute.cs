using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon_Appointment_App.Filter
{
    public class CustomizeAuthorizeAttribute:AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomizeAuthorizeAttribute(params string[] roles)
        {
            allowedRoles = roles;
        }

        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true) 
                ||filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller 
                return;
            }
            if(HttpContext.Current.Session["Username"]==null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}