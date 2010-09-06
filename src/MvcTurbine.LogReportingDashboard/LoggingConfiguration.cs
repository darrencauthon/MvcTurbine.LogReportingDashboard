using System;
using System.Collections.Generic;
using MvcTurbine.LogReportingDashboard.Logging;

namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration
    {
        private readonly LoggingRouteData loggingRouteData;
        private readonly IList<Type> loggersToExclude;

        public LoggingConfiguration(LoggingRouteData loggingRouteData)
        {
            this.loggingRouteData = loggingRouteData;
            loggersToExclude = new List<Type>();
        }

        public virtual void Configure()
        {
        }

        public LoggingRouteData LoggingRouteData
        {
            get { return loggingRouteData; }
        }

        public IEnumerable<Type> RepositoriesToExclude { get { return loggersToExclude; } }

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

        public void ExcludeThisLogger(Type type)
        {
            loggersToExclude.Add(type);
        }
    }
}