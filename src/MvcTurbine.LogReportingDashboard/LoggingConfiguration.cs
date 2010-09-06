using System;
using System.Collections.Generic;
using MvcTurbine.LogReportingDashboard.Logging;

namespace MvcTurbine.LogReportingDashboard
{
    public class LoggingConfiguration
    {
        private readonly LoggingRouteData loggingRouteData;
        private readonly LoggerExclusionSet loggerExclusionSet;

        public LoggingConfiguration(LoggingRouteData loggingRouteData,
            LoggerExclusionSet loggerExclusionSet)
        {
            this.loggingRouteData = loggingRouteData;
            this.loggerExclusionSet = loggerExclusionSet;
        }

        public virtual void Configure()
        {
        }

        public LoggingRouteData LoggingRouteData
        {
            get { return loggingRouteData; }
        }

        public IEnumerable<Type> RepositoriesToExclude { get { return loggerExclusionSet; } }

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
            loggerExclusionSet.Add(type);
        }
    }
}