namespace MvcTurbine.LogReportingDashboard
{
    public interface ILoggingRouteData
    {
        string LogDashboardPageName();
        bool AuthenticationIsRequired();
        bool TheQuerystringShouldBeUsed();
        string GetTheQueryStringKey();
        string GetTheQueryStringValue();
    }
}