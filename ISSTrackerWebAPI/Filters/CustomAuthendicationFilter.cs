using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ISSTrackerWebAPI.Models;
using System.Text;
System.Net.Http.Headers.

namespace ISSTrackerWebAPI.Filters
{
    public class CustomAuthendicationFilter : AuthorizationFilterAttribute
    {
        private bool EnableFilter = false;
        public CustomAuthendicationFilter()
        {

        }

        public CustomAuthendicationFilter(bool enalble)
        {
            this.EnableFilter = enalble;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!EnableFilter)
                return;




            base.OnAuthorization(actionContext);
        }



        public virtual BasicAuthenticationIdentity GetIdentity(HttpActionContext filterContext)
        {
            string authHeaderParam = null;
            System.Net.Http.Headers.AuthenticationHeaderValue authHeader = 
                filterContext.Request.Headers.Authorization;

            if (authHeader != null &&
                !string.IsNullOrEmpty(authHeader.Scheme) && authHeader.Scheme == "Basic")
            {
                authHeaderParam = authHeader.Parameter;
            }

            if (authHeaderParam == null)
                return null;


            var authHeaderValue = Encoding.Default.GetString(Convert.ToBase64String(authHeaderParam));


            var creditials = authHeaderValue.Split(':');

            if (creditials.Length < 2)
                return null;
            else
                return new BasicAuthenticationIdentity(creditials[0], creditials[1]);

        }
    }
}