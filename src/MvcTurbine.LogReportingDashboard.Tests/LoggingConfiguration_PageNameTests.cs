﻿using AutoMoq;
using MvcTurbine.LogReportingDashboard.Logging;
using NUnit.Framework;
using Should;

namespace MvcTurbine.LogReportingDashboard.Tests
{
    [TestFixture]
    public class LoggingConfiguration_PageNameTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void The_default_page_name_is_Logging()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();

            var result = configuration.LoggingRouteData.Page;

            result.ShouldEqual("_Logging");
        }

        [Test]
        public void UseThisPageName_will_set_the_name_of_the_page()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.PageName = "expected";
            configuration.Configure();

            var result = configuration.LoggingRouteData.Page;

            result.ShouldEqual("expected");
        }

        public class TestLoggingConfiguration : LoggingConfiguration
        {
            public string PageName { get; set; }

            public TestLoggingConfiguration()
                : base (new LoggingRouteData(), new LoggerExclusionSet()){}

            public override void Configure()
            {
                UseThisPage(PageName);
            }
        }
    }
}