using Serilog.Context;
using System;

namespace WhiteCoat.Utils.Standard.Log
{
	public class Logger: ILog
	{
		private readonly Serilog.ILogger _log;

		public Logger(Serilog.ILogger log)
		{
			_log = log;
		}

		public void Write(LogEventLevel level, string messageTemplate, params object[] propertyValues)
		{
			_log.Write((Serilog.Events.LogEventLevel)level, messageTemplate, propertyValues);
		}

		public void Write(LogEventLevel level, Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Write((Serilog.Events.LogEventLevel)level, exception, messageTemplate, propertyValues);
		}

		public bool IsEnabled(LogEventLevel level)
		{
			return _log.IsEnabled((Serilog.Events.LogEventLevel)level);
		}

		public void Verbose(string messageTemplate, params object[] propertyValues)
		{
			_log.Verbose(messageTemplate, propertyValues);
		}

		public void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Verbose(exception, messageTemplate, propertyValues);
		}

		public void Debug(string messageTemplate, params object[] propertyValues)
		{
			_log.Debug(messageTemplate, propertyValues);
		}

		public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Debug(exception, messageTemplate, propertyValues);
		}

		public void Information(string messageTemplate, params object[] propertyValues)
		{
			_log.Information(messageTemplate, propertyValues);
		}

		public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Information(exception, messageTemplate, propertyValues);
		}

		public void Warning(string messageTemplate, params object[] propertyValues)
		{
			_log.Warning(messageTemplate, propertyValues);
		}

		public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Warning(exception, messageTemplate, propertyValues);
		}

		public void Error(string messageTemplate, params object[] propertyValues)
		{
			_log.Error(messageTemplate, propertyValues);
		}

		public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Error(exception, messageTemplate, propertyValues);
		}

		public void Fatal(string messageTemplate, params object[] propertyValues)
		{
			_log.Fatal(messageTemplate, propertyValues);
		}

		public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
		{
			_log.Fatal(exception, messageTemplate, propertyValues);
		}

		public IDisposable PushProperty(string propertyName, string value)
		{
			return LogContext.PushProperty(propertyName, value);
		}

		public void LogError(Exception ex)
		{
			_log.Error(ex, string.Empty);
		}

		public void LogWarn(string message)
		{
			_log.Warning(message);
		}

		public void LogDebug(string message)
		{
			_log.Debug(message);
		}

		public void LogInfo(string message)
		{
			_log.Information(message);
		}

		public void Flush()
		{
		}
	}
}
