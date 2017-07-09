using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ISSTrackerWebAPI.Provider;
using System.Net.Http.Formatting;

namespace ISSTrackerWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);


            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new XmlMediaTypeFormatter());



            // Unity Container
            var container = new UnityContainer();
            container.RegisterType<Interface.INord, Provider.NORAD>(new HierarchicalLifetimeManager());
            container.RegisterType<Interface.IAuthInterface, Provider.AuthendicateUser>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}
