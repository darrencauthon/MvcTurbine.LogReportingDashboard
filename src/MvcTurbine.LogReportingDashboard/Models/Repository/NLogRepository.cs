using System;
using System.Linq;
using MvcTurbine.LogReportingDashboard.Models.Entities;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Models.Repository
{
    public class NLogRepository : ILogReportingRepository
    {
        private readonly MvcLoggingContainer context;

        public NLogRepository(MvcLoggingContainer context)
        {
            this.context = context;
        }

        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            var list = (from b in context.NLog_Error.ToList()
                        where b.time_stamp >= start && b.time_stamp <= end
                              && (b.level == logLevel || logLevel == "All")
                        select new LogEvent
                                   {
                                       IdType = "number"
                                       , Id = ""
                                       , IdAsInteger = b.Id
                                       , IdAsGuid = Guid.NewGuid()
                                       , LoggerProviderName = "NLog"
                                       , LogDate = b.time_stamp
                                       , MachineName = b.host
                                       , Message = b.message
                                       , Type = b.type
                                       , Level = b.level
                                       , Source = b.source
                                       , StackTrace = b.stacktrace
                                   })
                .ToList()
                .AsQueryable();

            return list;
        }

        public LogEvent GetById(string id)
        {
            var logEventId = Convert.ToInt32(id);

            var logEvent = (from b in context.NLog_Error
                            where b.Id == logEventId
                            select new LogEvent
                                       {
                                           IdType = "number"
                                           , IdAsInteger = b.Id
                                           , LoggerProviderName = "NLog"
                                           , LogDate = b.time_stamp
                                           , MachineName = b.host
                                           , Message = b.message
                                           , Type = b.type
                                           , Level = b.level
                                           , Source = b.source
                                           , StackTrace = b.stacktrace
                                           , AllXml = b.allxml
                                       })
                .FirstOrDefault();

            return logEvent;
        }

        public string DescriptiveName
        {
            get { return "NLog"; }
        }
    }
}