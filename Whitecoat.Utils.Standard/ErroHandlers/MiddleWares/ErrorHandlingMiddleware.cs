using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhiteCoat.Utilis.ErrorHandlers;

namespace WhiteCoat.Utilis.ErrorHandler.MiddleWares
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;
		ILogger _log;
		public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this.next = next;
			_log = loggerFactory.CreateLogger("General Error Handler");
		}

		public async Task Invoke(HttpContext context /* other dependencies */)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.Message);
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var code = HttpStatusCode.InternalServerError;
			
			//TODO:may need to specific different status code based on type of exceptions 

			var result = JsonConvert.SerializeObject(new ApiError(500, code.ToString(), ex.Message));

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
	}
}
