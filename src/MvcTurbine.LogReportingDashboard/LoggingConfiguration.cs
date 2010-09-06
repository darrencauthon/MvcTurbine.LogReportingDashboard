namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration
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

        protected void CheckForThisInTheQueryString(string key, string value)
        {
            LookForThisKeyInTheQueryString(key);
            LookForThisValueInTheQueryString(value);
        }

        private void LookForThisValueInTheQueryString(string value)
        {
            this.value = value;
        }

        private void LookForThisKeyInTheQueryString(string key)
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