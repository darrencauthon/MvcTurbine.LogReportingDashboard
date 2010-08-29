using System;
using System.Configuration;

namespace MvcTurbine.LogReportingDashboard.Services.Logging
{
    public static class LogFactory
    {
        /// <summary>
        ///   This static class returns the logger that is configured through the appSettings section of the web.config file
        ///   The default logger is NLog
        /// </summary>
        /// <returns>A concrete logger, usually an NLogLogger or Log4NetLogger</returns>
        public static ILogger Logger()
        {
            var defaultLoggerTypeName = "MvcTurbine.LogReportingDashboard.Services.Logging.NLog.NLogLogger";
            var loggerTypeName = ConfigurationManager.AppSettings["loggerTypeName"];
            loggerTypeName = (loggerTypeName == null) ? defaultLoggerTypeName : loggerTypeName;

            var loggerType = Type.GetType(loggerTypeName);
            var logger = Activator.CreateInstance(loggerType) as ILogger;

            return logger;
        }
    }
}