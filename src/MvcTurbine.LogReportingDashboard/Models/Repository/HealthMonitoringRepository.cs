using System;
using System.Linq;
using MvcTurbine.LogReportingDashboard.Models.Entities;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Models.Repository
{
    /// <summary>
    ///   This class extracts information that ASP.NET Health Monitoring stores so that we can report on it
    /// </summary>
    public class HealthMonitoringRepository : ILogReportingRepository
    {
        private readonly MvcLoggingContainer context;

        public HealthMonitoringRepository(MvcLoggingContainer context)
        {
            this.context = context;
        }

        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            var list = (from h in context.vw_aspnet_WebEvents_extended.ToList()
                        where h.EventTimeUtc >= start && h.EventTimeUtc <= end
                              && (h.Level == logLevel || logLevel == "All")
                        select new LogEvent
                                   {
                                       IdType = "string"
                                       , Id = h.EventId
                                       , IdAsInteger = 0
                                       //, IdAsGuid = Guid.NewGuid()
                                       , LoggerProviderName = "Health Monitoring"
                                       , LogDate = h.EventTimeUtc
                                       , MachineName = h.MachineName
                                       , Message = h.Message
                                       , Type = h.EventType
                                       , Level = h.Level
                                       , Source = h.RequestUrl
                                       , StackTrace = ""
                                   })
                .ToList()
                .AsQueryable();

            return list;
        }

        public LogEvent GetById(string id)
        {
            var logEvent = (from b in context.vw_aspnet_WebEvents_extended
                            where b.EventId == id
                            select new LogEvent
                                       {
                                           IdType = "string"
                                           , Id = b.EventId
                                           , LoggerProviderName = "Health Monitoring"
                                           , LogDate = b.EventTimeUtc
                                           , MachineName = b.MachineName
                                           , Message = b.Message
                                           , Type = b.EventType
                                           , Level = b.Level
                                           , Source = b.RequestUrl
                                           , StackTrace = ""
                                           , AllXml = ""
                                       })
                .FirstOrDefault();

            return logEvent;
        }

        public string DescriptiveName
        {
            get { return "Health Monitoring"; }
        }
    }
}