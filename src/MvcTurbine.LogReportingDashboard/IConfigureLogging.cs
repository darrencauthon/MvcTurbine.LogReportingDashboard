﻿namespace MvcTurbine.LogReportingDashboard
{
    public interface IConfigureLogging
    {
        void Configure();
        bool TheQuerystringShouldBeUsed();
        string GetTheQueryStringKey();
        string GetTheQueryStringValue();
    }
}