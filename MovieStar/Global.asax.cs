using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using log4net;
using Unity;
using Unity.AspNet.WebApi;

namespace MovieStar
{
    public class Global : HttpApplication
    {
        ILog log = LogManager.GetLogger(typeof(Global));

        void Application_Start(object sender, EventArgs e)
        {
            log.Info("Application Start");

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            log.Error("Application Error", exception);
        }
    }
}