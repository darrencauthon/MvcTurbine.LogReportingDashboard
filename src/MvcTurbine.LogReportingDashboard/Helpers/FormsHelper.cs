using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using MvcTurbine.LogReportingDashboard.Models.Repository;

namespace MvcTurbine.LogReportingDashboard.Helpers
{
    public class FormsHelper
    {
        public static string[] timeperiods = new[] {"Today", "Yesterday", "This Week", "Last Week", "This Month", "Last Month", "Last 30 days", "Last 60 days", "Last 90 days"};
        public static string[] log_levels = new[] {"All", "Debug", "Info", "Warning", "Error", "Fatal"};
        public static string[] paging_page_sizes = new[] {"10", "15", "20", "25", "30", "50", "100"};

        public static IEnumerable<SelectListItem> LogProviderNames
        {
            get
            {
                var repository = new LogReportingFacade();
                IDictionary<string, string> dict = repository.GetLogProviders();
                dict.Add("All", "All");
                var list = dict.OrderBy(item => item.Key).Select(o => new SelectListItem {Text = o.Key, Value = o.Key}).ToList();
                return list;
            }
        }

        public static IEnumerable<SelectListItem> LogLevels
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var item in log_levels)
                {
                    dict.Add(item, item);
                }
                var list = dict.Select(o => new SelectListItem {Text = o.Value, Value = o.Key}).ToList();
                return list;
            }
        }

        public static IEnumerable<SelectListItem> CommonTimePeriods
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var item in timeperiods)
                {
                    dict.Add(item, item);
                }
                var list = dict.Select(o => new SelectListItem {Text = o.Value, Value = o.Key}).ToList();
                return list;
            }
        }

        public static IEnumerable<SelectListItem> PagingPageSizes
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var item in paging_page_sizes)
                {
                    dict.Add(item, item);
                }
                var list = dict.Select(o => new SelectListItem {Text = o.Value, Value = o.Key}).ToList();
                return list;
            }
        }

        public static string OutputXmlTableForLogging(string xml)
        {
            var sb = new StringBuilder();

            if (!String.IsNullOrEmpty(xml))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                for (var index = 0; index < xmlDoc.DocumentElement.ChildNodes.Count; index++)
                {
                    var node = xmlDoc.DocumentElement.ChildNodes[index];

                    // Group header
                    sb.Append("<div>");
                    sb.Append("  <p class='table-caption'>" + node.Name + "</p>");

                    sb.Append("  <div class='scroll-view'>");

                    // Table for attributes
                    sb.Append("<table class='exception' cellspacing='1' style='border-collapse: collapse;'>");

                    sb.Append("<tr>");
                    sb.Append("  <th class='name-col' style='white-space: nowrap;'>Name</th>");
                    sb.Append("  <th class='value-col'>Value</th>");
                    sb.Append("</tr>");

                    for (var childIndex = 0; childIndex < node.ChildNodes.Count; childIndex++)
                    {
                        var childNode = node.ChildNodes[childIndex];

                        var rowClass = childIndex%2 == 1 ? "even-row" : "odd-row";

                        sb.Append(string.Format("<tr class='{0}'>", rowClass));
                        sb.Append("  <td class='key-col'>" + childNode.Attributes["name"].InnerText + "</td>");
                        sb.Append("  <td class='value-col'>" + childNode.FirstChild.Attributes["string"].InnerText + "</td>");
                        sb.Append("</tr>");
                    }

                    sb.Append("</table>");
                    // ------------------------

                    sb.Append("  </div>");
                    sb.Append("</div>");
                }
            }

            return sb.ToString();
        }
    }
}