using System;
using System.Collections.Generic;
using System.Linq;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;
using MvcTurbine.LogReportingDashboard.Services.Paging;

namespace MvcTurbine.LogReportingDashboard.Models.Repository
{
    /// <summary>
    ///   This class provides a facade over all of our LogReport repositories
    /// </summary>
    public class LogReportingFacade : ILogReportingFacade
    {
        private Dictionary<string, ILogReportingRepository> logProviders;

        /// <summary>
        ///   Overloaded constructor that can take an EntityContainer as a parameter so that it can be mocked out by our tests
        /// </summary>
        /// <param name = "logReportingRepositories"></param>
        public LogReportingFacade(ILogReportingRepository[] logReportingRepositories)
        {
            logProviders = new Dictionary<string, ILogReportingRepository>();
            foreach (var logReportingRepository in logReportingRepositories)
                logProviders.Add(logReportingRepository.DescriptiveName, logReportingRepository);
        }

        /// <summary>
        ///   Creates and returns an instance of a log provider
        /// </summary>
        /// <param name = "logProviderName">The type name of the log provider</param>
        /// <returns>An instance of a log provider</returns>
        private ILogReportingRepository GetProvider(string logProviderName)
        {
            return logProviders[logProviderName];
        }

        /// <summary>
        ///   Gets a filtered list of log events
        /// </summary>
        /// <param name = "pageIndex">0 based page index</param>
        /// <param name = "pageSize">max number of records to return</param>
        /// <param name = "start">start date</param>
        /// <param name = "end">end date</param>
        /// <param name = "logProviderName">name of the log provider</param>
        /// <param name = "logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public IPagedList<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logProviderName, string logLevel)
        {
            IQueryable<LogEvent> list = null;

            switch (logProviderName)
            {
                case "All":
                    foreach (var providerName in logProviders.Keys)
                    {
                        var logList = GetProvider(providerName).GetByDateRangeAndType(pageIndex, pageSize, start, end, logLevel);
                        list = (list == null) ? logList : list.Union(logList);
                    }
                    break;

                default:
                    list = GetProvider(logProviderName).GetByDateRangeAndType(pageIndex, pageSize, start, end, logLevel);
                    break;
            }

            list = list.OrderByDescending(d => d.LogDate);

            return new PagedList<LogEvent>(list, pageIndex, pageSize);
        }

        /// <summary>
        ///   Returns a single Log event
        /// </summary>
        /// <param name = "logProviderName">name of the log provider</param>
        /// <param name = "id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public LogEvent GetById(string logProviderName, string id)
        {
            var logEvent = GetProvider(logProviderName).GetById(id);
            return logEvent;
        }

        /// <summary>
        ///   Clears log messages between a date range and for specified log levels
        /// </summary>
        /// <param name = "logProviderName">name of the log provider</param>
        /// <param name = "start">start date</param>
        /// <param name = "end">end date</param>
        /// <param name = "logLevels">string array of log levels</param>
        public void ClearLog(string logProviderName, DateTime start, DateTime end, string[] logLevels)
        {
            GetProvider(logProviderName).ClearLog(start, end, logLevels);
        }

        /// <summary>
        ///   Returns a list of all registered log providers
        /// </summary>
        /// <returns>A list of all registered log providers</returns>
        public IEnumerable<string> GetLogProviders()
        {
            return logProviders.Keys;
        }
    }
}