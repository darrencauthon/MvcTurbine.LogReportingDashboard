using AutoMoq;
using MvcTurbine.LogReportingDashboard.Logging;
using NUnit.Framework;
using Should;

namespace MvcTurbine.LogReportingDashboard.Tests
{
    [TestFixture]
    public class LoggingConfiguration_QuerystringDataTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void The_querystring_is_not_used_by_default()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();
            configuration.Configure();

            var result = configuration.LoggingRouteData.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_string_is_used_when_a_key_and_value_are_set()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.Key = "Key";
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.LoggingRouteData.TheQuerystringShouldBeUsed;

            result.ShouldBeTrue();
        }

        [Test]
        public void The_string_is_not_used_when_a_key_is_not_set()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.Key = "Key";

            configuration.Configure();

            var result = configuration.LoggingRouteData.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_string_is_not_used_when_a_value_is_not_set()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.LoggingRouteData.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_querystring_key_is_set_by_the_LookForThisKeyInTheQueryString_method()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.Key = "Key";

            configuration.Configure();

            var result = configuration.LoggingRouteData.QueryStringKey;

            result.ShouldEqual("Key");
        }

        [Test]
        public void The_querystring_value_is_set_by_the_LookForThisValueInTheQueryString_method()
        {
            var configuration = mocker.Resolve<TestLoggingConfiguration>();
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.LoggingRouteData.QueryStringValue;

            result.ShouldEqual("Value");
        }

        public class TestLoggingConfiguration : LoggingConfiguration
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public TestLoggingConfiguration()
                : base(new LoggingRouteData()){}

            public override void Configure()
            {
                CheckForThisInTheQueryString(Key, Value);
            }
        }
    }
}