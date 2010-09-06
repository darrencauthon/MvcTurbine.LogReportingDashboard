using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Logging
{
    public class RoutingData : MvcTurbine.LogReportingDashboard.LoggingRouteData
    {
        public override void Configure()
        {
            base.Configure();
            UseThisPage("Logging2");
        }
    }
}