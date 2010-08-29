using MvcTurbine.Blades;
using MvcTurbine.LogReportingDashboard.Services.Logging.NLog;
using NLog;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class NLogSetupBlade : Blade
    {
        public override void Spin(IRotorContext context)
        {
            SetRenderersForValuesThatWillBeSavedToTheDatabase();
        }

        private static void SetRenderersForValuesThatWillBeSavedToTheDatabase()
        {
            LayoutRendererFactory.AddLayoutRenderer("utc_date", typeof (UtcDateRenderer));
            LayoutRendererFactory.AddLayoutRenderer("web_variables", typeof (WebVariablesRenderer));
        }
    }
}