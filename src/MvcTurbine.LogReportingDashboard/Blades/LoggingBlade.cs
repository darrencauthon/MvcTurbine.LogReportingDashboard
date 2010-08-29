using System.Web.Mvc;
using MvcTurbine.Blades;
using MvcTurbine.LogReportingDashboard.Services.Logging.Elmah;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LoggingBlade : Blade
    {
        public override void Spin(IRotorContext context)
        {
            var locator = context.ServiceLocator;
            locator.Register<IControllerFactory, ErrorHandlingControllerFactory>();
            locator.Register<IActionInvoker, ErrorHandlingActionInvoker>();
        }
    }
}