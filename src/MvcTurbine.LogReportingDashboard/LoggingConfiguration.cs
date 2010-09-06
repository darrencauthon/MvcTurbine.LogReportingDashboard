using MvcTurbine.LogReportingDashboard.Logging;

namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration
    {
        private readonly LoggingRouteData loggingRouteData;

        public LoggingConfiguration(LoggingRouteData loggingRouteData)
        {
            this.loggingRouteData = loggingRouteData;
        }

        public virtual void Configure()
        {
        }

        public LoggingRouteData LoggingRouteData
        {
            get { return LoggingRouteData; }
        }

        protected void RequireTheUserToBeAuthenticated()
        {
            loggingRouteData.RequireAuthentication = true;
        }

        protected void CheckForThisInTheQueryString(string key, string value)
        {
            loggingRouteData.QueryStringKey = key;
            loggingRouteData.QueryStringValue = value;
        }

        protected void UseThisPage(string page)
        {
            loggingRouteData.Page = page;
        }
    }
}