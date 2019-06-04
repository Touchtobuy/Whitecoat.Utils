using System;

namespace WhiteCoat.Utils.Standard.Log
{
	public interface ILog
	{
		void Write(LogEventLevel level, string messageTemplate, params object[] propertyValues);
		void Write(LogEventLevel level, Exception exception, string messageTemplate, params object[] propertyValues);
		bool IsEnabled(LogEventLevel level);
		void Verbose(string messageTemplate, params object[] propertyValues);
		void Verbose(Exception exception, string messageTemplate, params object[] propertyValues);
		void Debug(string messageTemplate, params object[] propertyValues);
		void Debug(Exception exception, string messageTemplate, params object[] propertyValues);
		void Information(string messageTemplate, params object[] propertyValues);
		void Information(Exception exception, string messageTemplate, params object[] propertyValues);
		void Warning(string messageTemplate, params object[] propertyValues);
		void Warning(Exception exception, string messageTemplate, params object[] propertyValues);
		void Error(string messageTemplate, params object[] propertyValues);
		void Error(Exception exception, string messageTemplate, params object[] propertyValues);
		void Fatal(string messageTemplate, params object[] propertyValues);
		void Fatal(Exception exception, string messageTemplate, params object[] propertyValues);
		IDisposable PushProperty(string propertyName, string value);
		void LogError(Exception ex);
		void LogWarn(string message);
		void LogDebug(string message);
		void LogInfo(string message);
	}
}
