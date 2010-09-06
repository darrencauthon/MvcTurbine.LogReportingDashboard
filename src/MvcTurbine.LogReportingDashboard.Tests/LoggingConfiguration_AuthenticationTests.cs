using AutoMoq;
using MvcTurbine.LogReportingDashboard.Logging;
using NUnit.Framework;
using Should;

namespace MvcTurbine.LogReportingDashboard.Tests
{
    [TestFixture]
    public class LoggingConfiguration_AuthenticationNameTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Authentication_is_not_required_by_default()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();
            configuration.Configure();

            var result = configuration.LoggingRouteData.RequireAuthentication;

            result.ShouldBeFalse();
        }

        [Test]
        public void Authentication_is_required_when_RequireTheUserToBeAuthenticated_is_called()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.RequireAuthentication = true;
            configuration.Configure();

            var result = configuration.LoggingRouteData.RequireAuthentication;

            result.ShouldBeTrue();
        }

        public class TestLoggingConfiguration : LoggingConfiguration
        {
            public bool RequireAuthentication { get; set; }

            public TestLoggingConfiguration()
                : base(new LoggingRouteData(), new LoggerExclusionSet())
            {
            }

            public override void Configure()
            {
                if (RequireAuthentication)
                    RequireTheUserToBeAuthenticated();
            }
        }
    }
}