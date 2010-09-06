namespace MvcTurbine.LogReportingDashboard
{
    public class DefaultRouteData
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

        public bool TheQuerystringShouldBeUsed()
        {
            return string.IsNullOrEmpty(key) == false &&
                   string.IsNullOrEmpty(value) == false;
        }

        public string GetTheQueryStringKey()
        {
            return key;
        }

        public string GetTheQueryStringValue()
        {
            return value;
        }
    }
}