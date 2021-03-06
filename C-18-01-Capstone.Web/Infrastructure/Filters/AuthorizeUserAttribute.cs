﻿using System.ComponentModel.Composition;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using C_18_01_Capstone.Web.Services;

namespace C_18_01_Capstone.Web.Infrastructure.Filters
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        [Import]
        public IApiClient ApiClient { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string login = (string)httpContext.Session["Login"];
            string hashedPassword = (string)httpContext.Session["HashedPassword"];
            
            return true;
        }

        protected override void HandleUnauthorizedRequest(
            AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "User",
                        action = "Login"
                    })
               );
        }
    }
}