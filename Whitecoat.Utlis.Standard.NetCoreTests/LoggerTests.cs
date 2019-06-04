using Serilog;
using Serilog.Core;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using WhiteCoat.Utils.Standard.Log;
using Xunit;
using LogEventLevel = Serilog.Events.LogEventLevel;
using LoggerFactory = WhiteCoat.Utils.Standard.Log.LoggerFactory;

namespace Whitecoat.Utlis.Standard.NetCoreTests
{
	public class LoggerTests
		{
			const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss fff zzz} [{Level}] {Message}{NewLine}{Exception}";
			const string PropertyA = "Replacement A";
			private ILog GetLogger(TextWriter writer)
			{
				//Write log events to the provided System.IO.TextWriter.
				return new LoggerFactory(new LoggerConfiguration().MinimumLevel.Is(LogEventLevel.Verbose)
						.WriteTo.TextWriter(writer, LogEventLevel.Verbose, OutputTemplate)).ForContext<LoggerTests>();
			}

			[Fact()]
			public void VerboseTestWithTemplate_PassExceptionAndMessage_LogFormatIsCorrect()
			{
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var logger = GetLogger(messages);

					var exception = new Exception("This is a test Exception"); 
					logger.Verbose("Test Logger {propertyA:l}", PropertyA);
					logger.Verbose(exception, "");
					messages.Flush(); 
					Assert.Contains("[Verbose] Test Logger Replacement A", sb.ToString());
					Assert.Contains( "This is a test Exception", sb.ToString());
				}
			}

			[Fact()]
			public void InformationTest_PassExceptionAndMessage_LogFormatIsCorrect()
			{
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var logger = GetLogger(messages);
					var exception = new Exception("This is a test Exception");
					logger.Information("Test Logger {propertyA:l}", PropertyA);
					logger.Information(exception, "");
					messages.Flush();
					Assert.Contains( "[Information] Test Logger Replacement A", sb.ToString());
					Assert.Contains("This is a test Exception", sb.ToString());
				}
			}

			[Fact()]
			public void WarningTestt_PassExceptionAndMessage_LogFormatIsCorrect()
			{
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var logger = GetLogger(messages);
					var exception = new Exception("This is a test Exception");
					logger.Warning("Test Logger {propertyA:l}", PropertyA);
					logger.Warning(exception, "");
					messages.Flush();
					Assert.Contains("[Warning] Test Logger Replacement A", sb.ToString());
					Assert.Contains("This is a test Exception", sb.ToString());
				}
			}

			[Fact()]
			public void ErrorTestt_PassExceptionAndMessage_LogFormatIsCorrect()
			{
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var logger = GetLogger(messages);
					var exception = new Exception("This is a test Exception");
					logger.Error("Test Logger {propertyA:l}", PropertyA);
					logger.Error(exception, "");
					messages.Flush();
					Assert.Contains("[Error] Test Logger Replacement A", sb.ToString());
					Assert.Contains("This is a test Exception", sb.ToString());
				}
			}

			[Fact()]
			public void FatalTest_PassExceptionAndMessage_LogFormatIsCorrect()
			{
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var logger = GetLogger(messages);
					var exception = new Exception("This is a test Exception");
					logger.Fatal("Test Logger {propertyA:l}", PropertyA);
					logger.Fatal(exception, "");
					messages.Flush();
					Assert.Contains("[Fatal] Test Logger Replacement A", sb.ToString());
					Assert.Contains("This is a test Exception", sb.ToString());
				}
			}

			[Fact]
			public void GetGlobalLoggerTest_PassExceptionAndMessage_LogFormatIsCorrect()
			{
			
				var factory = new LoggerFactory(new LoggerConfiguration());

				var globalLogger = factory.ForGeneral();
				var contextLogger = factory.ForContext(typeof(LoggerTests));

				Assert.NotNull(globalLogger);
				Assert.NotNull(contextLogger);
			}

			[Fact]
			public void LoggerFactoryIntializeTest_IntializeDefaultWithConfigure_LogFormatIsCorrect()
			{
				//arrange
				var sb = new StringBuilder();
				using (var messages = new StringWriter(sb))
				{
					var config = new LoggerConfiguration().MinimumLevel.Is(LogEventLevel.Verbose)
					.WriteTo.TextWriter(messages, LogEventLevel.Verbose, OutputTemplate);
					LoggerFactory.InitializeDefaultLogger(config);

					//action
					var logger = new LoggerFactory().ForContext<LoggerTests>();
					var exception = new Exception("This is a test Exception");
					logger.Verbose("Test Logger {propertyA:l}", PropertyA);
					logger.Verbose(exception, "");
					messages.Flush();

					//assert
					Assert.Contains("[Verbose] Test Logger Replacement A", sb.ToString());
					Assert.Contains("This is a test Exception", sb.ToString());
				}

			 
			}

	}
	
}
