using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteCoat.Utils.Standard.Http;

namespace Whitecoat.Utils.Standard.ClientAdapters
{
	public interface IBackEndProxy
	{
		Task<T> Get<T>(string url);
		Task<T> Get<T>(string url, IDictionary<string, string> queryStringParameters);
		Task<T> Get<T>(string url, IDictionary<string, string> queryStringParameters, List<KeyValuePair<string, string>> urlParameters);
		Task<TR> Post<T, TR>(string url, T data);
	}

	public class DefaultBackEndProxy : IBackEndProxy
	{
		private readonly IHttpClientManager _httpClientManager;
		public DefaultBackEndProxy(IHttpClientManager httpClientManager)
		{
			_httpClientManager = httpClientManager;
		}

		public  async Task<T> Get<T>(string url)
		{
			return await Get<T>(url, null);
		}

		public  async Task<T> Get<T>(string url, IDictionary<string, string> queryStringParameters)
		{
			return await Get<T>(url, queryStringParameters, null);
		}

		public  async Task<T> Get<T>(string url, IDictionary<string, string> queryStringParameters, List<KeyValuePair<string, string>> urlParameters)
		{
			var requestUrl = url + urlParameters.AsUrlParameters();
			var responseMessage = await _httpClientManager.GetAsync(requestUrl, queryStringParameters, null);
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(responseMessage.ReasonPhrase);

			var json = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(json);
		}

		public async Task<TR> Post<T, TR>(string url, T data)
		{
			var responseMessage = await _httpClientManager.PostAsync(url, JsonConvert.SerializeObject(data));  

			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception(responseMessage.ReasonPhrase);

			var json = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TR>(json);
		}
	}
}
