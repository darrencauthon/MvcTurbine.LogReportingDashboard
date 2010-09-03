namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration : IConfigureLogging
    {
        private string pageName = "Logging";
        private string key;
        private string value;
        private bool requireTheUserToBeAuthenticated;

        public void Configure()
        {
            RequireTheUserToBeAuthenticated();
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
    }
}