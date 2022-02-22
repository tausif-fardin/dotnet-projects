using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationDemo.Auth 
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authenticated = base.AuthorizeCore(httpContext);
            if (!authenticated)
                return false;

            if (httpContext.Session["UserType"].ToString().Equals("Admin")) { return true; }
            else { return false; }

            //return base.AuthorizeCore(httpContext);
        }
    }
}