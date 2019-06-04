using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WhiteCoat.Utils.Standard.Http
{
	public interface IHttpClientManager
	{
		Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
		Task<HttpResponseMessage> PostAsync(string url,
			string serializedContent,
			IDictionary<string, string> headers = null,
			string mediaType = "application/json");
		Task<HttpResponseMessage> GetAsync(
			string url,
			IDictionary<string, string> parameters,
			IDictionary<string, string> headers = null);		 
	}

	public class HttpClientManager : IHttpClientManager
	{
		private HttpClient _client;
		public HttpClientManager()
		{
			_client = new HttpClient();
		}

		public async Task<HttpResponseMessage> PostAsync(
			string url,
			string serializedContent,
			IDictionary<string, string> headers,
			string mediaType = "application/json")
		{
			var request = CreatePostRequest(url, serializedContent, headers, mediaType);
			return await _client.SendAsync(request);
		}

		public async Task<HttpResponseMessage> GetAsync(
			string url,
			IDictionary<string, string> parameters,
			IDictionary<string, string> headers)
		{
			var request = CreateGetRequest(url, parameters, headers);
			return await SendAsync(request);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
		{
			return _client.SendAsync(request);
		}

		private HttpRequestMessage CreatePostRequest(
			string url, 
			string serializedContent, 
			IDictionary<string, string> headers, 
			string mediaType = "application/json")
		{
			var builder = new UriBuilder(url);
			var request = new HttpRequestMessage(HttpMethod.Post, builder.Uri)
				{
					Content = new StringContent(serializedContent,
									Encoding.UTF8,
									mediaType),
					Method = HttpMethod.Post
				}; 
			if (headers == null)
				return request;

			foreach (var key in headers.Keys)
				request.Headers.Add(key, headers[key]);
			return request;
		}

		private HttpRequestMessage CreateGetRequest(
			string url,
			IDictionary<string, string> parameters = null,
			IDictionary<string, string> headers = null)
		{
			var builder = new UriBuilder(url);
			var requestUrl = builder.Uri + parameters?.AsQueryString() ?? "";
			var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

			if (headers == null)
				return request;

			foreach (var key in headers.Keys)
				request.Headers.Add(key, headers[key]);
			return request;
		}

	}
}
