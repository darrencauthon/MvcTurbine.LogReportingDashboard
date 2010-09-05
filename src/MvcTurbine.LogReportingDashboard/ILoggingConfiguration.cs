namespace MvcTurbine.LogReportingDashboard
{
    public interface ILoggingConfiguration
    {
        void Configure();
        string LogDashboardPageName();
        bool AuthenticationIsRequired();
        bool TheQuerystringShouldBeUsed();
        string GetTheQueryStringKey();
        string GetTheQueryStringValue();
    }
}