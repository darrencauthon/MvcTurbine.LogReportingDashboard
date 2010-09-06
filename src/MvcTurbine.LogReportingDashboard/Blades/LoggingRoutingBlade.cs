﻿using System;
using System.Collections.Generic;
using System.Linq;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.LogReportingDashboard.Blades
{
    public class LoggingRoutingBlade : Blade, ISupportAutoRegistration
    {
        private readonly IServiceLocator serviceLocator;

        public LoggingRoutingBlade(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public override void Spin(IRotorContext context)
        {
            // 
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            //registrationList.Add(ComponentModel.Registration.Simple<ILoggingRouteData>());

            var list = new List<Type>();

            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(x => x.GetTypes()
                .Where(y=>y == typeof(LoggingRouteData) || y.BaseType == typeof(LoggingRouteData))
                .ToList().ForEach(z=>list.Add(z)));

            var loggingData = serviceLocator.Resolve<LoggingRouteData>(list
                .OrderBy(x => x == typeof(LoggingRouteData) ? 1 : 0)
                .First());

            loggingData.Configure();

            serviceLocator.Register(loggingData);
        }
    }
}