using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.Routing;

namespace SampleApplication.Routing
{
    public class DefaultRegistration : IRouteRegistrator
    {
        public void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}, // Parameter defaults
                new {controller = new ControllerInThisAssemblyRestraint()}
                );
        }
    }

    public class ControllerInThisAssemblyRestraint : IRouteConstraint
    {
        private readonly IEnumerable<string> list;

        public ControllerInThisAssemblyRestraint()
        {
            list = (this).GetType().Assembly
                .GetTypes()
                .Where(x => x.BaseType == typeof (Controller))
                .Select(x => x.Name.Substring(0, x.Name.Length - "Controller".Length));
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return list.Contains((string) values["controller"]);
        }
    }
}