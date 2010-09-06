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

        public string Page
        {
            get { return loggingRouteData.Page; }
        }

        public bool AuthenticationIsRequired
        {
            get { return loggingRouteData.RequireAuthentication; }
        }

        public bool TheQuerystringShouldBeUsed
        {
            get
            {
                return string.IsNullOrEmpty(loggingRouteData.QueryStringKey) == false &&
                       string.IsNullOrEmpty(loggingRouteData.QueryStringValue) == false;
            }
        }

        public string QueryStringKey
        {
            get { return loggingRouteData.QueryStringKey; }
        }

        public string QueryStringValue
        {
            get { return loggingRouteData.QueryStringValue; }
        }
    }
}