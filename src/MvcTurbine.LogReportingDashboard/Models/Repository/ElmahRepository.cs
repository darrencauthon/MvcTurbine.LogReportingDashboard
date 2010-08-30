using System;
using System.Linq;
using MvcTurbine.LogReportingDashboard.Models.Entities;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Models.Repository
{
    public class ElmahRepository : ILogReportingRepository
    {
        private readonly MvcLoggingContainer context;

        public ElmahRepository(MvcLoggingContainer context)
        {
            this.context = context;
        }

        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            var list = (from a in context.ELMAH_Error.ToList()
                        where a.TimeUtc >= start && a.TimeUtc <= end
                              && (logLevel == "All" || logLevel == "Error")
                        select new LogEvent
                                   {
                                       IdType = "guid"
                                       , Id = ""
                                       , IdAsInteger = 0
                                       , IdAsGuid = a.ErrorId
                                       , LoggerProviderName = "Elmah"
                                       , LogDate = a.TimeUtc
                                       , MachineName = a.Host
                                       , Message = a.Message
                                       , Type = a.Type
                                       , Level = "Error"
                                       , Source = a.Source, StackTrace = ""
                                   })
                .ToList()
                .AsQueryable();

            return list;
        }

        public LogEvent GetById(string id)
        {
            var guid = new Guid(id);
            var logEvent = (from b in context.ELMAH_Error
                            where b.ErrorId == guid
                            select new LogEvent
                                       {
                                           IdType = "guid"
                                           , IdAsGuid = b.ErrorId
                                           , LoggerProviderName = "Elmah"
                                           , LogDate = b.TimeUtc
                                           , MachineName = b.Host
                                           , Message = b.Message
                                           , Type = b.Type
                                           , Level = "Error"
                                           , Source = b.Source
                                           , StackTrace = ""
                                           , AllXml = b.AllXml
                                       })
                .FirstOrDefault();

            return logEvent;
        }

        public string DescriptiveName
        {
            get { return "ELMAH"; }
        }
    }
}