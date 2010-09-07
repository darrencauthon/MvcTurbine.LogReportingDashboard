MvcTurbine.LogReportingDashboard
========

MvcTurbine.LogReportingDashboard is a small plugin for MVC Turbine that adds the Log Reporting Dashboard that Darren Weir created (read [here](http://www.codeproject.com/KB/aspnet/mvc_logging.aspx) and [here](http://dotnetdarren.wordpress.com/2010/07/27/logging-on-mvc-part-1/).  By adding a reference to MvcTurbine.LogReportingDashboard and adding the appropriate configuration, you will get:

1.)  Out-of-the-box [ELMAH](http://code.google.com/p/elmah/) integration with all of your controllers. This means you do not have to create and attach a custom HandleError-like attribute to every controller.

2.)  Auto-registration of an ILogger interface with a NLog implementation (log4net coming soon).  This means that you can instantiate a fully-set-up logger simply by adding a dependency to ILogger.

3.)  NLog, Asp.Net Health Monitoring, and ELMAH logging to your database.

4.)  A dashboard that shows all logged events.

5.)  A detail page for each of the logged events, showing things like the date/time of the event, the IP address of the visitor that experienced the issue, a stack trace for debugging, etc..

6.)  Automatic routing set to /_Logging and features for securing the logging dashboard, all of which are configurable.

A short video demo of its setup and dashboard [is available here](http://www.youtube.com/watch?v=Hicjp5MODpI).

