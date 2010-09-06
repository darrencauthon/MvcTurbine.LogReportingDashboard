using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using MvcTurbine.LogReportingDashboard.Models;
using MvcTurbine.LogReportingDashboard.Models.Repository.Interfaces;
using NUnit.Framework;
using Should;

namespace MvcTurbine.LogReportingDashboard.Tests
{
    [TestFixture]
    public class LoggingConfiguration_IncludeOnlyTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Configuration_loads_with_no_loggers_to_exclude()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();

            configuration.RepositoriesToExclude.Count().ShouldEqual(0);
        }

        [Test]
        public void ExcludeThisLogger_adds_to_list_of_types_to_remove()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();

            configuration.ExcludeThisLogger(typeof(Test1LoggingRepository));

            configuration.RepositoriesToExclude.Count().ShouldEqual(1);
            configuration.RepositoriesToExclude.Contains(typeof (Test1LoggingRepository))
                .ShouldBeTrue();
        }

        [Test]
        public void Can_exclude_multiple_types()
        {
            var configuration = mocker.Resolve<LoggingConfiguration>();

            configuration.ExcludeThisLogger(typeof(Test1LoggingRepository));
            configuration.ExcludeThisLogger(typeof(Test2LoggingRepository));

            configuration.RepositoriesToExclude.Count().ShouldEqual(2);
            configuration.RepositoriesToExclude.Contains(typeof(Test1LoggingRepository))
                .ShouldBeTrue();
            configuration.RepositoriesToExclude.Contains(typeof(Test2LoggingRepository))
                .ShouldBeTrue();
        }

    }

    public class Test1LoggingRepository : ILogReportingRepository
    {
        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            throw new NotImplementedException();
        }

        public LogEvent GetById(string id)
        {
            throw new NotImplementedException();
        }

        public string DescriptiveName
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Test2LoggingRepository : ILogReportingRepository
    {
        public IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            throw new NotImplementedException();
        }

        public LogEvent GetById(string id)
        {
            throw new NotImplementedException();
        }

        public string DescriptiveName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
