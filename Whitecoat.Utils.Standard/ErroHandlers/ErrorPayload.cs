using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteCoat.Utilis.ErrorHandlers
{
	public class ApiError
	{
		public string StatusDescript { get; private set; }
		public  int StatusCode { get; private set; }

		public string  Message { get; private set; }
		public ApiError(int statusCode, string statusDescript, string message)
		{
			StatusCode = statusCode;
			Message = message;
			StatusDescript = statusDescript;
		}		
	}
}
