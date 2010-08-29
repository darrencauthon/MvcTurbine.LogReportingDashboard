using System.Web.Mvc;
using System.Web.Routing;
using MvcTurbine.ComponentModel;
using MvcTurbine.Web.Controllers;

namespace MvcTurbine.LogReportingDashboard.Services.Logging.Elmah
{
    /// <summary>
    ///   This custom controller factory injects a custom attribute 
    ///   on every action that is invoked by the controller
    /// </summary>
    public class ErrorHandlingControllerFactory : TurbineControllerFactory
    {
        private readonly IServiceLocator serviceLocator;

        public ErrorHandlingControllerFactory(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        ///   Injects a custom attribute 
        ///   on every action that is invoked by the controller
        /// </summary>
        /// <param name = "requestContext">The request context</param>
        /// <param name = "controllerName">The name of the controller</param>
        /// <returns>An instance of a controller</returns>
        public override IController CreateController(
            RequestContext requestContext,
            string controllerName)
        {
            var controller =
                base.CreateController(requestContext,
                                      controllerName);

            var c = controller as Controller;

            if (c != null)
            {
                c.ActionInvoker =
                    new ErrorHandlingActionInvoker(serviceLocator,
                                                   new HandleErrorWithELMAHAttribute());
            }

            return controller;
        }
    }
}