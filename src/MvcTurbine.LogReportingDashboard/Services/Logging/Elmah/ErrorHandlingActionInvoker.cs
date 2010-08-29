﻿using System;
using System.Web.Mvc;
using MvcTurbine.ComponentModel;
using MvcTurbine.Web.Controllers;

namespace MvcTurbine.LogReportingDashboard.Services.Logging.Elmah
{
    /// <summary>
    ///   This class allows an Exception filter to be injected when an MVC action is invoked
    /// </summary>
    public class ErrorHandlingActionInvoker : TurbineActionInvoker
    {
        private readonly IExceptionFilter filter;

        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name = "filter">The exception filter to inject</param>
        public ErrorHandlingActionInvoker(IServiceLocator serviceLocator, IExceptionFilter filter)
            : base(serviceLocator)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            this.filter = filter;
        }

        /// <summary>
        ///   This methods returns all of the normal filters used
        ///   PLUS it appends our custom filter to the end of the list
        /// </summary>
        /// <param name = "controllerContext">The context of the controller</param>
        /// <param name = "actionDescriptor">The action descriptor</param>
        /// <returns>All of the action filters</returns>
        protected override FilterInfo GetFilters(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var filterInfo =
                base.GetFilters(controllerContext,
                                actionDescriptor);

            filterInfo.ExceptionFilters.Add(filter);

            return filterInfo;
        }
    }
}