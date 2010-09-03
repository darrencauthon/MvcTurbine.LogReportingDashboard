using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LogginRoutingBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            throw new NotImplementedException();
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(MvcTurbine.ComponentModel.Registration.Custom<ILoggingRouteData>())
        }
    }
}