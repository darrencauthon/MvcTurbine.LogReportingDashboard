﻿namespace MvcTurbine.LogReportingDashboard.Services.Charting.Google.Visualization
{
    public class ChartColumn
    {
        /// <summary>
        ///   Id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///   Label
        /// </summary>
        public string label { get; set; }

        /// <summary>
        ///   Type
        /// </summary>
        public string type { get; set; }

        public ChartColumn(string id, string label, string type)
        {
            this.id = id;
            this.label = label;
            this.type = type;
        }
    }
}