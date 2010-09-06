using MvcTurbine.LogReportingDashboard;
using MvcTurbine.LogReportingDashboard.Logging;
using MvcTurbine.LogReportingDashboard.Models.Repository;

namespace SampleApplication.Logging
{
    public class DefaultLoggingConfiguration : LoggingConfiguration
    {
        public DefaultLoggingConfiguration(LoggingRouteData loggingRouteData, LoggerExclusionSet loggerExclusionSet)
            : base(loggingRouteData, loggerExclusionSet)
        {
        }

        public override void Configure()
        {
            UseThisPage("Logging1234");
            //ExcludeThisLogger(typeof(HealthMonitoringRepository));
            //ExcludeThisLogger(typeof(ElmahRepository));
        }
    }
}