using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhiteCoat.Utils.Standard.Http
{
	public static class HttpUtilityExtensions
	{
		public static string AsQueryString(this IDictionary<string, string> queryParams)
		{
			if (!queryParams.Any())
				return string.Empty;

			var builder = new StringBuilder();

			var separator = "?";
			foreach (var item in queryParams)
			{
				builder.AppendFormat("{0}{1}={2}", separator, Uri.EscapeUriString(item.Key), Uri.EscapeUriString(item.Value));
				separator = "&";
			}

			return builder.ToString();
		}

		// To guarantee items' insertion order, this extension methold should be used for List
		public static string AsUrlParameters(this IList<KeyValuePair<string, string>> urlParams)
		{
			if (!urlParams.Any())
				return string.Empty;

			var builder = new StringBuilder();

			var separator = "/";
			foreach (var item in urlParams)
			{
				builder.AppendFormat("{0}{1}", separator, Uri.EscapeUriString(item.Value));
			}

			return builder.ToString();
		}
	}
}
