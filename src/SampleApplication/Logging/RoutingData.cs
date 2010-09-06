using MvcTurbine.LogReportingDashboard;

namespace SampleApplication.Logging
{
    public class RoutingData : LoggingRouteData
    {
        public override void Configure()
        {
            base.Configure();
            UseThisPage("Logging2");
            CheckForThisInTheQueryString("Key", "Value");
        }
    }
}