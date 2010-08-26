using System.Web.Mvc;
using MvcLoggingDemo.Services;
using MvcTurbine;
using MvcTurbine.Blades;

namespace MvcLoggingDemo.Blades
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