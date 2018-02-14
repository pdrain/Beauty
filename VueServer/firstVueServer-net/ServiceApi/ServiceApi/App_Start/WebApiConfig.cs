using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ServiceApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            RouteTable.Routes.MapHttpRoute(
               name: "actionapi",
               routeTemplate: "api2/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           ).RouteHandler = new SessionControllerRouteHandler();

            config.EnableSystemDiagnosticsTracing();
        }
    }

    public class SessionRouteHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionRouteHandler(RouteData routeData)
            : base(routeData)
        {

        }
    }

    public class SessionControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {

            return new SessionRouteHandler(requestContext.RouteData);

        }

    }
}
