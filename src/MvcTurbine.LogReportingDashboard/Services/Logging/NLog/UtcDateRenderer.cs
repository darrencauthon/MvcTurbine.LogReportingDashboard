﻿using System.Globalization;
using System.Text;
using NLog;
using NLog.Config;

namespace MvcTurbine.LogReportingDashboard.Services.Logging.NLog
{
    [LayoutRenderer("utc_date")]
    public class UtcDateRenderer : LayoutRenderer
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "UtcDateRenderer" /> class.
        /// </summary>
        public UtcDateRenderer()
        {
            Format = "G";
            CultureInfo = CultureInfo.InvariantCulture;
        }

        protected override int GetEstimatedBufferSize(LogEventInfo ev)
        {
            // Dates can be 6, 8, 10 bytes so let's go with 10
            return 10;
        }

        /// <summary>
        ///   Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
        /// </summary>
        /// <docgen category = 'Rendering Options' order = '10' />
        [DefaultParameter]
        public string Format { get; set; }

        /// <summary>
        ///   Renders the current date and appends it to the specified <see cref = "StringBuilder" />.
        /// </summary>
        /// <param name = "builder">The <see cref = "StringBuilder" /> to append the rendered data to.</param>
        /// <param name = "logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(logEvent.TimeStamp.ToUniversalTime().ToString(Format, CultureInfo));
        }
    }
}