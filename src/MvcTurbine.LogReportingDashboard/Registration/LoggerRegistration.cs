using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Services.Logging;
using MvcTurbine.LogReportingDashboard.Services.Logging.NLog;

namespace MvcTurbine.LogReportingDashboard.Registration
{
    public class LoggerRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            HardcodeTheNLogLogger(locator);
        }

        private static void HardcodeTheNLogLogger(IServiceLocator locator)
        {
            locator.Register<ILogger, NLogLogger>();
        }
    }
}