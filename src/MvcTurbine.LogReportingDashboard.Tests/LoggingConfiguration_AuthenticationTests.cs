using AutoMoq;
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
            var configuration = mocker.Resolve<DefaultRouteData>();
            configuration.Configure();

            var result = configuration.AuthenticationIsRequired();

            result.ShouldBeFalse();
        }

        [Test]
        public void Authentication_is_required_when_RequireTheUserToBeAuthenticated_is_called()
        {
            var configuration = mocker.Resolve<TestDefaultRouteData>();
            configuration.RequireAuthentication = true;
            configuration.Configure();

            var result = configuration.AuthenticationIsRequired();

            result.ShouldBeTrue();
        }

        public class TestDefaultRouteData : DefaultRouteData
        {
            public bool RequireAuthentication { get; set; }

            public override void Configure()
            {
                if (RequireAuthentication)
                    RequireTheUserToBeAuthenticated();
            }
        }
    }
}