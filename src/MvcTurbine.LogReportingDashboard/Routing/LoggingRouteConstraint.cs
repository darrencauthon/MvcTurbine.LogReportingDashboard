using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Logging;

namespace MvcTurbine.LogReportingDashboard.Routing
{
    public class LoggingRouteConstraint : IRouteConstraint
    {
        private readonly IServiceLocator serviceLocator;

        public LoggingRouteConstraint(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public bool Match(HttpContextBase httpContext, Route route,
                          string parameterName, RouteValueDictionary values,
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

        private static bool TheQueryStringValuesDoNotMatch(LoggingRouteData loggingConfiguration)
        {
            return loggingConfiguration.TheQueryStringShouldBeUsed &&
                   (HttpContext.Current.Request[loggingConfiguration.QueryStringKey] !=
                    loggingConfiguration.QueryStringValue);
        }

        private static bool AuthenticationIsRequiredButCurrentUserIsNot(LoggingRouteData loggingConfiguration)
        {
            return loggingConfiguration.RequireAuthentication &&
                   HttpContext.Current.User.Identity.IsAuthenticated == false;
        }

        private static bool TheControllerNameDoesNotMatch(RouteValueDictionary values, LoggingRouteData loggingConfiguration)
        {
            var page = GetTheCurrentPage();
            return string.Compare(page, loggingConfiguration.Page, StringComparison.CurrentCultureIgnoreCase) != 0;
        }

        private static string GetTheCurrentPage()
        {
            return HttpContext.Current.Request.Url.Segments
                .FirstOrDefault(x => x != "/");
        }

        private LoggingRouteData GetTheLoggingRouteData()
        {
            return serviceLocator.Resolve<LoggingRouteData>();
        }
    }
}