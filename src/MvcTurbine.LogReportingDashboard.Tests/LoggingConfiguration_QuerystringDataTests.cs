using AutoMoq;
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
            var configuration = mocker.Resolve<LoggingRouteData>();
            configuration.Configure();

            var result = configuration.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_string_is_used_when_a_key_and_value_are_set()
        {
            var configuration = mocker.Resolve<TestLoggingRouteData>();
            configuration.Key = "Key";
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.TheQuerystringShouldBeUsed;

            result.ShouldBeTrue();
        }

        [Test]
        public void The_string_is_not_used_when_a_key_is_not_set()
        {
            var configuration = mocker.Resolve<TestLoggingRouteData>();
            configuration.Key = "Key";

            configuration.Configure();

            var result = configuration.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_string_is_not_used_when_a_value_is_not_set()
        {
            var configuration = mocker.Resolve<TestLoggingRouteData>();
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.TheQuerystringShouldBeUsed;

            result.ShouldBeFalse();
        }

        [Test]
        public void The_querystring_key_is_set_by_the_LookForThisKeyInTheQueryString_method()
        {
            var configuration = mocker.Resolve<TestLoggingRouteData>();
            configuration.Key = "Key";

            configuration.Configure();

            var result = configuration.QueryStringKey;

            result.ShouldEqual("Key");
        }

        [Test]
        public void The_querystring_value_is_set_by_the_LookForThisValueInTheQueryString_method()
        {
            var configuration = mocker.Resolve<TestLoggingRouteData>();
            configuration.Value = "Value";

            configuration.Configure();

            var result = configuration.QueryStringValue;

            result.ShouldEqual("Value");
        }

        public class TestLoggingRouteData : LoggingRouteData
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public override void Configure()
            {
                LookForThisKeyInTheQueryString(Key);
                LookForThisValueInTheQueryString(Value);
            }
        }
    }
}