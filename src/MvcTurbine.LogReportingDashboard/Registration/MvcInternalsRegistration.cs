using System.Web.Mvc;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Services.Logging.Elmah;

namespace MvcTurbine.LogReportingDashboard.Registration
{
    public class MvcInternalsRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            ReplaceTheControllerAndActionInvokerToErrorHandlingOnes(locator);
        }

        private static void ReplaceTheControllerAndActionInvokerToErrorHandlingOnes(IServiceLocator locator)
        {
            locator.Register<IControllerFactory, ErrorHandlingControllerFactory>();
            locator.Register<IActionInvoker, ErrorHandlingActionInvoker>();
        }
    }
}