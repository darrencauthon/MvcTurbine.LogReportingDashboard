using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using MvcTurbine.ComponentModel;

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

        private static bool TheQueryStringValuesDoNotMatch(LoggingRouteData loggingRouteData)
        {
            return loggingRouteData.TheQuerystringShouldBeUsed &&
                   (HttpContext.Current.Request[loggingRouteData.QueryStringKey] !=
                    loggingRouteData.QueryStringValue);
        }

        private static bool AuthenticationIsRequiredButCurrentUserIsNot(LoggingRouteData loggingRouteData)
        {
            return loggingRouteData.AuthenticationIsRequired &&
                   HttpContext.Current.User.Identity.IsAuthenticated == false;
        }

        private static bool TheControllerNameDoesNotMatch(RouteValueDictionary values, LoggingRouteData loggingRouteData)
        {
            var page = GetTheCurrentPage();
            return string.Compare(page, loggingRouteData.Page, StringComparison.CurrentCultureIgnoreCase) != 0;
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