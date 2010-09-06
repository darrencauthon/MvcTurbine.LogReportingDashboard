namespace MvcTurbine.LogReportingDashboard.Logging
{
    public class LoggingRouteData
    {
        public LoggingRouteData()
        {
            Page = "Logging";
        }

        public string Page { get; set; }
        public string QueryStringKey { get; set; }
        public string QueryStringValue { get; set; }
        public bool RequireAuthentication { get; set; }

        public bool TheQuerystringShouldBeUsed
        {
            get { return false; }
        }
    }
}