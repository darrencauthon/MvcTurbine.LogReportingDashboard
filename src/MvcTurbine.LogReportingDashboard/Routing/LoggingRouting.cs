using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.ComponentModel;
using MvcTurbine.Routing;

namespace MvcTurbine.LogReportingDashboard.Routing
{
    public class LoggingRouting : IRouteRegistrator
    {
        private readonly LoggingRouteConstraint constraint;
        private readonly IServiceLocator serviceLocator;

        public LoggingRouting(LoggingRouteConstraint constraint,
                              IServiceLocator serviceLocator)
        {
            this.constraint = constraint;
            this.serviceLocator = serviceLocator;
        }

        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "Logging",
                GetThePageName() + "/{action}/{id}",
                new {controller = "Logging", action = "Index", id = UrlParameter.Optional},
                new {controller = constraint}
                );
        }

        private string GetThePageName()
        {
            return serviceLocator.Resolve<LoggingRouteData>()
                .Page;
        }
    }
}