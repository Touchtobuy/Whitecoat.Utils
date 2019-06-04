using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace WhiteCoat.Utils.Standard.Log
{
	public static class LoggerExtensions
	{
		// add logger into .net core log pipeline
		public static ILoggerFactory AddLoggerInNetCore(
			this ILoggerFactory factory)
		{
			if (factory == null) throw new ArgumentNullException(nameof(factory));
			return factory.AddSerilog();
		}


		public static IWebHostBuilder UseWCLogger(
			this IWebHostBuilder builder)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			builder.UseSerilog();

			return builder;
		}
	}
}
