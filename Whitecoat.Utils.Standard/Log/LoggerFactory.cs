using Serilog;
using System;


namespace WhiteCoat.Utils.Standard.Log
{
	public interface ILogFactory
	{
		ILog ForContext<TSource>();
		ILog ForContext(Type source);
		ILog ForGeneral();
	}

	public class LoggerFactory
	{
		public static void InitializeDefaultLoggerFromAppSettings()
		{
			Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
		}

		public static void InitializeDefaultLogger(LoggerConfiguration loggerConfiguration)
		{
			Serilog.Log.Logger = loggerConfiguration.CreateLogger();
		}

		public LoggerFactory(LoggerConfiguration loggerConfiguration = null)
		{
			_logger = loggerConfiguration?.CreateLogger() ?? Serilog.Log.Logger;
		}
		
		private readonly ILogger _logger;

		public ILog ForContext<TSource>()
		{
			return new Logger(_logger.ForContext<TSource>());
		}

		public ILog ForContext(Type source)
		{
			return new Logger(_logger.ForContext(source));
		}

		public ILog ForGeneral()
		{
			return new Logger(_logger);
		}
	}
}
