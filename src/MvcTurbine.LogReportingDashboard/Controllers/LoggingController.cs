using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcTurbine.LogReportingDashboard.Helpers;
using MvcTurbine.LogReportingDashboard.Models;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;
using MvcTurbine.LogReportingDashboard.Services.Charting.Google.Visualization;
using MvcTurbine.LogReportingDashboard.ViewModels;
using MvcTurbine.LogReportingDashboard.Services.Paging;
using System.ServiceModel.Syndication;
using MvcTurbine.LogReportingDashboard.ActionResults;

namespace MvcTurbine.LogReportingDashboard.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ILogReportingFacade loggingRepository;

        public LoggingController(ILogReportingFacade repository)
        {
            loggingRepository = repository;
        }

        public ActionResult Index(string Period, string LoggerProviderName, string LogLevel, int? page, int? PageSize)
        {
            // Set up our default values
            var defaultPeriod = Session["Period"] == null ? "Today" : Session["Period"].ToString();
            var defaultLogType = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
            var defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();

            // Set up our view model
            var model = new LoggingIndexModel();

            model.Period = (Period == null) ? defaultPeriod : Period;
            model.LoggerProviderName = (LoggerProviderName == null) ? defaultLogType : LoggerProviderName;
            model.LogLevel = (LogLevel == null) ? defaultLogLevel : LogLevel;
            model.CurrentPageIndex = page.HasValue ? page.Value - 1 : 0;
            model.PageSize = PageSize.HasValue ? PageSize.Value : 20;

            var timePeriod = TimePeriodHelper.GetUtcTimePeriod(model.Period);

            // Grab the data from the database
            model.LogEvents = loggingRepository.GetByDateRangeAndType(model.CurrentPageIndex, model.PageSize, timePeriod.Start, timePeriod.End, model.LoggerProviderName, model.LogLevel);

            // Put this into the ViewModel so our Pager can get at these values
            ViewData["Period"] = model.Period;
            ViewData["LoggerProviderName"] = model.LoggerProviderName;
            ViewData["LogLevel"] = model.LogLevel;
            ViewData["PageSize"] = model.PageSize;

            // Put the info into the Session so that when we browse away from the page and come back that the last settings are rememberd and used.
            Session["Period"] = model.Period;
            Session["LoggerProviderName"] = model.LoggerProviderName;
            Session["LogLevel"] = model.LogLevel;

            return View(model);
        }

        public ActionResult Details(string loggerProviderName, string id)
        {
            var logEvent = loggingRepository.GetById(loggerProviderName, id);

            return View(logEvent);
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult ChartData(string Period, string LoggerProviderName, string LogLevel)
        {
            if (Period == "Today" || Period == "Yesterday")
            {
                return ChartDataByHour(Period, LoggerProviderName, LogLevel);
            }
            else
            {
                return ChartDataByDay(Period, LoggerProviderName, LogLevel);
            }
        }

        public JsonResult ChartDataByHour(string Period, string LoggerProviderName, string logLevel)
        {
            Func<LogEvent, Object> groupByClause = c => c.LogDate.ToLocalTime().Hour;

            return ChartDataByTimePeriod(Period, LoggerProviderName, logLevel, "", groupByClause);
        }

        public JsonResult ChartDataByDay(string Period, string LoggerProviderName, string logLevel)
        {
            Func<LogEvent, Object> groupByClause = c => c.LogDate.ToLocalTime().Date;

            return ChartDataByTimePeriod(Period, LoggerProviderName, logLevel, "dd/MM/yyyy", groupByClause);
        }

        public JsonResult ChartDataByTimePeriod(string Period, string LoggerProviderName, string logLevel, string keyFormatString, Func<LogEvent, Object> groupByClause)
        {
            var timePeriod = TimePeriodHelper.GetUtcTimePeriod(Period);

            // Grab ALL entries for the chart (DO NOT PAGE REPORTING DATA!!!)
            var chartEntries = loggingRepository.GetByDateRangeAndType(0, Int32.MaxValue, timePeriod.Start, timePeriod.End, LoggerProviderName, logLevel);

            var groupedByDate = chartEntries.GroupBy(groupByClause).OrderBy(y => y.Key);

            var groupedByDateAndThenName = groupedByDate.Select(group => new {group.Key, NestedGroup = group.ToLookup(result => result.LoggerProviderName, result => result.Id)});

            var LoggerNames = (from logEvent in chartEntries
                               select new {Name = logEvent.LoggerProviderName}
                              ).Distinct().OrderBy(item => item.Name);

            var chartData = new ChartData();

            // Add columns
            chartData.AddColumn(new ChartColumn("0", "Period", "string"));
            var columnIndex = 1;
            foreach (var name in LoggerNames)
            {
                chartData.AddColumn(new ChartColumn(columnIndex.ToString(), name.Name, "number"));
                columnIndex++;
            }

            // add row data
            foreach (var myDate in groupedByDateAndThenName)
            {
                var row = new ChartRow();

                var dateString = (myDate.Key is DateTime) ? ((DateTime) myDate.Key).ToString(keyFormatString) : myDate.Key.ToString();
                row.AddCellItem(new ChartCellItem(dateString, ""));

                foreach (var name in LoggerNames)
                {
                    var valueFound = false;
                    foreach (var myLogger in myDate.NestedGroup)
                    {
                        if (myLogger.Key == name.Name)
                        {
                            row.AddCellItem(new ChartCellItem(myLogger.Count(), ""));
                            valueFound = true;
                        }
                    }
                    if (!valueFound) row.AddCellItem(new ChartCellItem(0, ""));
                }

                chartData.AddRow(row);
            }

            return Json(chartData, "text/x-json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart(string Period, string LoggerProviderName, string LogLevel)
        {
            var defaultPeriod = Session["Period"] == null ? "Today" : Session["Period"].ToString();
            var defaultLoggerProviderName = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
            var defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();

            var model = new LoggingIndexModel();

            model.Period = (Period == null) ? defaultPeriod : Period;
            model.LoggerProviderName = (LoggerProviderName == null) ? defaultLoggerProviderName : LoggerProviderName;
            model.LogLevel = (LogLevel == null) ? defaultLogLevel : LogLevel;

            return View(model);
        }

        public FeedResult RssFeed(string Period, string LoggerProviderName, string LogLevel)
        {
            string defaultPeriod = Session["Period"] == null ? "This Week" : Session["Period"].ToString();
            string defaultLoggerProviderName = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
            string defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();

            Period = (Period == null) ? defaultPeriod : Period;
            LoggerProviderName = (LoggerProviderName == null) ? defaultLoggerProviderName : LoggerProviderName;
            LogLevel = (LogLevel == null) ? defaultLogLevel : LogLevel;

            TimePeriod timePeriod = TimePeriodHelper.GetUtcTimePeriod(Period);

            // Grab ALL entries for the feed (DO NOT PAGE feed DATA!!!)
            IPagedList<LogEvent> chartEntries = loggingRepository.GetByDateRangeAndType(0, Int32.MaxValue, timePeriod.Start, timePeriod.End, LoggerProviderName, LogLevel);

            var postItems = chartEntries.Select(p => new SyndicationItem(string.Format("{0} - {1} - {2}", p.LogDate, p.Level, p.LoggerProviderName), p.Message, new Uri(Url.AbsoluteAction("Details", new { LoggerProviderName = p.LoggerProviderName, Id = p.Id }))));

            Uri feedAlternateLink = Url.ActionFull("Index", "Logging");

            var feed = new SyndicationFeed("MVC Logging Demo -> Log Reporting", string.Format("Log Provider: {0}, Log Level : {1}, From {2} to {3} ({4})", LoggerProviderName, LogLevel, timePeriod.Start.ToShortDateString(), timePeriod.End.ToShortDateString(), Period), feedAlternateLink, postItems)
            {
                Language = "en-US"
            };

            return new FeedResult(new Rss20FeedFormatter(feed));
        }
    }
}