namespace MvcTurbine.LogReportingDashboard
{
    public interface ILoggingRouteData
    {
        void Configure();
        string LogDashboardPageName();
        bool AuthenticationIsRequired();
        bool TheQuerystringShouldBeUsed();
        string GetTheQueryStringKey();
        string GetTheQueryStringValue();
    }
}