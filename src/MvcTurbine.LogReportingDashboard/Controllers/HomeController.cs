using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLoggingDemo.Services.Logging;

namespace MvcTurbine.LogReportingDashboard.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            logger.Debug("TESTING");
            logger.Info("INFO");
            logger.Fatal("FATAL");
            logger.Warn("FATAL");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
