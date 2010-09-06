using System;
using System.Collections.Generic;
using System.Linq;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Logging;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LoggingRoutingBlade : Blade, ISupportAutoRegistration
    {
        private readonly IServiceLocator serviceLocator;

        public LoggingRoutingBlade(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public override void Spin(IRotorContext context)
        {
            // nothing
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            RegisterASingleInstanceOfTheRoutingData();

            var loggingConfiguration = GetTheLoggingConfiguration();
            loggingConfiguration.Configure();
        }

        private void RegisterASingleInstanceOfTheRoutingData()
        {
            serviceLocator.Register(new LoggingRouteData());
        }

        private LoggingConfiguration GetTheLoggingConfiguration()
        {
            var list = GetAllLoggingConfigurations();

            return serviceLocator.Resolve<LoggingConfiguration>(
                list.OrderBy(PlaceAnyLoggingConfigurationThatIsNotTheDefaultFirst)
                    .First());
        }

        private static int PlaceAnyLoggingConfigurationThatIsNotTheDefaultFirst(Type x)
        {
            return x == typeof (LoggingConfiguration) ? 1 : 0;
        }

        private static IEnumerable<Type> GetAllLoggingConfigurations()
        {
            var list = new List<Type>();

            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(x => x.GetTypes()
                                  .Where(
                                      y =>
                                      y == typeof (LoggingConfiguration) || y.BaseType == typeof (LoggingConfiguration))
                                  .ToList().ForEach(list.Add));
            return list;
        }
    }
}