using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.Routing;

namespace MvcLoggingDemo.Routing
{
    public class LoggingRouting : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "Log", // Route name
                "{controller}/{action}/{LoggerProviderName}/{id}", // URL with parameters
                new {controller = "Logging", action = "Details"},
                new {controller = "Logging"}// Parameter defaults
                );
        }
    }
}