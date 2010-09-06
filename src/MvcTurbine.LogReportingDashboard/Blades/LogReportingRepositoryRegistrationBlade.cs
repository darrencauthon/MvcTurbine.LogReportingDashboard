﻿using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LogReportingRepositoryRegistrationBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            // nothing
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(
                ComponentModel.Registration.Custom<ILogReportingRepository>(RegistrationFilters.DefaultFilter,
                                                                            (locator, type) =>
                                                                            locator.Register<ILogReportingRepository>(type)));
        }
    }
}