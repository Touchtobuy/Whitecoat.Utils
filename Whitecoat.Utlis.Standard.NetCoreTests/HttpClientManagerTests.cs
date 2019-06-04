using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WhiteCoat.Utils.Standard.Http;
using Xunit;

namespace Whitecoat.Utlis.Standard.NetCoreTests
{
	public class HttpClientManagerTests
	{
		IHttpClientManager _httpClientManager;
		string testUrl = "https://google.com.au";

		public HttpClientManagerTests()
		{
			_httpClientManager = new HttpClientManager();
		}

		[Fact()]
		public async Task SendAsyncTest_SendRequest_Successfully()
		{
			//arrange
			var request = new HttpRequestMessage(HttpMethod.Get, new Uri(testUrl));

			//action
			var response = await _httpClientManager.SendAsync(request);

			//assert
			Assert.True(response.IsSuccessStatusCode);			
		}

		[Fact()]
		public async Task GetAsync()
		{
			//arrange
			var a = new Dictionary<string, string>();
			//action
			var response = await _httpClientManager.GetAsync(testUrl, null);
			
			//assert
			Assert.True(response.IsSuccessStatusCode);
		}
	}
}
