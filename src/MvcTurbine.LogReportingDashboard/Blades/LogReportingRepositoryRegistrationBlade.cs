using System;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Logging;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LogReportingRepositoryRegistrationBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            // nothing
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(
                ComponentModel.Registration.Custom<ILogReportingRepository>(
                    RegistrationFilters.DefaultFilter, RegisterLogReportingRepositoriesThatAreNotExcluded));
        }

        private static void RegisterLogReportingRepositoriesThatAreNotExcluded(IServiceLocator locator, Type type)
        {
            if (locator.Resolve<LoggerExclusionSet>().Contains(type) == false)
                locator.Register<ILogReportingRepository>(type);
        }
    }
}