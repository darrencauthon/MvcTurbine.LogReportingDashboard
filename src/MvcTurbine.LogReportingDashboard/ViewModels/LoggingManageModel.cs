using System;
using System.ComponentModel.DataAnnotations;

namespace MvcTurbine.LogReportingDashboard.ViewModels
{
    public class LoggingManageModel
    {
        [DataType("DateTime")]
        public DateTime StartDate { get; set; }

        [DataType("DateTime")]
        public DateTime EndDate { get; set; }

        public string LogSourceName { get; set; }

        public string LogLevels { get; set; }

        public LoggingManageModel()
        {            
        }        
    }
}