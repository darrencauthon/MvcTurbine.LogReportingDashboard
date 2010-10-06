using System;
using System.Web;
using System.Web.Mvc;
using MvcTurbine.LogReportingDashboard.Services.Logging;

namespace SampleApplication.Controllers
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
            logger.Error("UH OH");

            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            throw new HttpException(404, "Action not found");

            return View();
        }
    }
}