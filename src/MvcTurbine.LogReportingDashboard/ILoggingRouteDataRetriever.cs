namespace MvcTurbine.LogReportingDashboard
{
    public interface ILoggingRouteDataRetriever
    {
        string LogDashboardPageName();
        bool AuthenticationIsRequired();
    }
}