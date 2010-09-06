using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Models.Entities;
using MvcTurbine.LogReportingDashboard.Models.Repository;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Registration
{
    public class ProjectRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<ILogReportingFacade, LogReportingFacade>();
            locator.Register(() => new MvcLoggingContainer());

            var routingData = new DefaultRouteData();
            locator.Register<DefaultRouteData>(routingData);
        }
    }
}