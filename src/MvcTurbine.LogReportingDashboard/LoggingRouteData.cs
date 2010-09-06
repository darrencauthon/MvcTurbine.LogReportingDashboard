namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingRouteData
    {
        private string page = "Logging";
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

        protected void UseThisPage(string page)
        {
            this.page = page;
        }

        public string Page
        {
            get { return page; }
        }

        public bool AuthenticationIsRequired
        {
            get { return requireTheUserToBeAuthenticated; }
        }

        public bool TheQuerystringShouldBeUsed
        {
            get
            {
                return string.IsNullOrEmpty(key) == false &&
                       string.IsNullOrEmpty(value) == false;
            }
        }

        public string QueryStringKey
        {
            get { return key; }
        }

        public string QueryStringValue
        {
            get { return value; }
        }
    }
}