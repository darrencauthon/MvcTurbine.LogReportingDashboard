using System;
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

        public LoggingRouting(LoggingRouteConstraint constraint)
        {
            this.constraint = constraint;
        }

        public void Register(RouteCollection routes)
        {
            routes.MapRoute(
                "Logging",
                "{controller}/{action}/{id}",
                new {controller = "x", action = "Index", id = UrlParameter.Optional},
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

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
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

        private bool TheQueryStringValuesDoNotMatch(ILoggingRouteData loggingRouteData)
        {
            return loggingRouteData.TheQuerystringShouldBeUsed() &&
                   (HttpContext.Current.Request[loggingRouteData.GetTheQueryStringKey()] != loggingRouteData.GetTheQueryStringValue());
        }

        private bool AuthenticationIsRequiredButCurrentUserIsNot(ILoggingRouteData loggingRouteData)
        {
            return loggingRouteData.AuthenticationIsRequired() && HttpContext.Current.User.Identity.IsAuthenticated == false;
        }

        private bool TheControllerNameDoesNotMatch(RouteValueDictionary values, ILoggingRouteData loggingRouteData)
        {
            return string.Compare((string) values["controller"], loggingRouteData.LogDashboardPageName(), StringComparison.CurrentCultureIgnoreCase) != 0;
        }

        private ILoggingRouteData GetTheLoggingRouteData()
        {
            return serviceLocator.Resolve<ILoggingRouteData>();
        }
    }
}