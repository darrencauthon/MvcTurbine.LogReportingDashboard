using System.Web.Mvc;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Services.Logging;
using MvcTurbine.LogReportingDashboard.Services.Logging.Elmah;
using MvcTurbine.LogReportingDashboard.Services.Logging.NLog;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LoggingRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IControllerFactory, ErrorHandlingControllerFactory>();
            locator.Register<IActionInvoker, ErrorHandlingActionInvoker>();

            locator.Register<ILogger, NLogLogger>();
        }
    }
}