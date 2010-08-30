using System;
using System.Collections.Generic;
using System.Linq;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;
using MvcTurbine.LogReportingDashboard.Services.Paging;

namespace MvcTurbine.LogReportingDashboard.Models.Repository
{
    public class LogReportingFacade : ILogReportingFacade
    {
        private readonly ILogReportingRepository[] logReportingRepositories;

        public LogReportingFacade(ILogReportingRepository[] logReportingRepositories)
        {
            this.logReportingRepositories = logReportingRepositories;
        }

        private ILogReportingRepository GetProvider(string logProviderName)
        {
            return logReportingRepositories.First(x => string.Compare(x.DescriptiveName, logProviderName, true) == 0);
        }

        public IPagedList<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logProviderName, string logLevel)
        {
            IQueryable<LogEvent> list = null;

            switch (logProviderName)
            {
                case "All":
                    foreach (var providerName in logReportingRepositories.Select(x => x.DescriptiveName))
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

        public LogEvent GetById(string logProviderName, string id)
        {
            var logEvent = GetProvider(logProviderName).GetById(id);
            return logEvent;
        }

        public void ClearLog(string logProviderName, DateTime start, DateTime end, string[] logLevels)
        {
            GetProvider(logProviderName).ClearLog(start, end, logLevels);
        }

        public IEnumerable<string> GetLogProviders()
        {
            return logReportingRepositories.Select(x => x.DescriptiveName);
        }
    }
}