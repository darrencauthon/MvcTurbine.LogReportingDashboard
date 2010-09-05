using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LoggingRoutingBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(ComponentModel.Registration.Simple<ILoggingRouteData>());
        }
    }
}