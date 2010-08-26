using MvcLoggingDemo.Services.Logging;
using MvcLoggingDemo.Services.Logging.Log4Net;
using MvcTurbine.ComponentModel;

namespace MvcLoggingDemo.Registration
{
    public class LoggerRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<ILogger, Log4NetLogger>();
        }
    }
}