using System;
using System.Configuration;

namespace MvcTurbine.LogReportingDashboard.Services.Logging
{
    public static class LogFactory
    {
        /// <summary>
        /// This static class returns the logger that is configured through the appSettings section of the web.config file
        /// The default logger is NLog
        /// </summary>
        /// <returns>A concrete logger, usually an NLogLogger or Log4NetLogger</returns>
        public static ILogger Logger()
        {
            string defaultLoggerTypeName = "MvcTurbine.LogReportingDashboard.Services.Logging.NLog.NLogLogger";
            string loggerTypeName = ConfigurationManager.AppSettings["loggerTypeName"];
            loggerTypeName = (loggerTypeName == null) ? defaultLoggerTypeName : loggerTypeName;

            Type loggerType = Type.GetType(loggerTypeName);
            ILogger logger = Activator.CreateInstance(loggerType) as ILogger;

            return logger;
        }
    }
}