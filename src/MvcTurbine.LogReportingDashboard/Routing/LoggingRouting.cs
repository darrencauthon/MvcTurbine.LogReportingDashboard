using System;
using System.Linq;
using System.Web;
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
            var loggingPageName = serviceLocator.Resolve<DefaultRouteData>()
                .LogDashboardPageName();

            routes.MapRoute(
                "Logging",
                loggingPageName + "/{action}/{id}",
                new {controller = "Logging", action = "Index", id = UrlParameter.Optional},
                new {controller = constraint}
                );
        }
    }

    public class LoggingRouteConstraint : IRouteConstraint
    {
        private readonly IServiceLocator serviceLocator;

        public LoggingRouteConstraint(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            var loggingRouteData = GetTheLoggingRouteData();

            if (TheControllerNameDoesNotMatch(values, loggingRouteData))
                return false;

            if (AuthenticationIsRequiredButCurrentUserIsNot(loggingRouteData))
                return false;

            if (TheQueryStringValuesDoNotMatch(loggingRouteData))
                return false;

            return true;
        }

        private bool TheQueryStringValuesDoNotMatch(DefaultRouteData loggingRouteData)
        {
            return loggingRouteData.TheQuerystringShouldBeUsed() &&
                   (HttpContext.Current.Request[loggingRouteData.GetTheQueryStringKey()] !=
                    loggingRouteData.GetTheQueryStringValue());
        }

        private bool AuthenticationIsRequiredButCurrentUserIsNot(DefaultRouteData loggingRouteData)
        {
            return loggingRouteData.AuthenticationIsRequired() &&
                   HttpContext.Current.User.Identity.IsAuthenticated == false;
        }

        private bool TheControllerNameDoesNotMatch(RouteValueDictionary values, DefaultRouteData loggingRouteData)
        {
            var controllerName = HttpContext.Current.Request.Url.Segments
                .FirstOrDefault(x => x != "/");
            return
                string.Compare(controllerName, loggingRouteData.LogDashboardPageName(),
                               StringComparison.CurrentCultureIgnoreCase) != 0;
        }

        private DefaultRouteData GetTheLoggingRouteData()
        {
            return serviceLocator.Resolve<DefaultRouteData>();
        }
    }
}