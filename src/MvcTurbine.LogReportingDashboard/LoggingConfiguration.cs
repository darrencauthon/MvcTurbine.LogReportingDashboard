namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration : IConfigureLogging
    {
        private string pageName = "Logging";
        private string key;
        private string value;
        private bool requireTheUserToBeAuthenticated;

        public virtual void Configure()
        {
        }

        protected void RequireTheUserToBeAuthenticated()
        {
            requireTheUserToBeAuthenticated = true;
        }

        protected void LookForThisValueInTheQueryString(string value)
        {
            this.value = value;
        }

        protected void LookForThisKeyInTheQueryString(string key)
        {
            this.key = key;
        }

        protected void UseThisPage(string pageName)
        {
            this.pageName = pageName;
        }

        public string LogDashboardPageName()
        {
            return pageName;
        }

        public bool AuthenticationIsRequired()
        {
            return requireTheUserToBeAuthenticated;
        }
    }
}