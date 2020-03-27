using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Xunit;

namespace Ecommerce.API.IntegrationTest
{
	public class ProductsControllerTests
	{
		private readonly HttpClient _client;
		private const string BaseUrl = "http://localhost:4006/";
	
		public ProductsControllerTests()
		{
			_client = new HttpClient {BaseAddress = new Uri(BaseUrl)};

		}
		
		[Fact]
		public async void Get_ReturnsAllProducts()
		{
			var response = await _client.GetAsync("products");

			if (response.IsSuccessStatusCode)
			{
				var responseMessage = await response.Content.ReadAsStringAsync();
				var responseData = JsonConvert.DeserializeObject<Returns>(responseMessage);
				
				Assert.NotNull(responseData);
				Assert.True( responseData.Success);
				
				var products = JsonConvert.DeserializeObject<List<ProductModel>>(responseData.Data.ToString());
				var firstProduct = products.FirstOrDefault();
				
				Assert.Equal("Macbook Pro", firstProduct.Name);
			}
		}

		[Theory]
		[InlineData("8F11AD71-D7E7-45EF-AF9E-D54EF0675C77")]
		[InlineData("0B68BD71-74B7-45F0-9382-916FC5CB52D8")]
		public async void Get_ReturnsOneProduct(string id)
		{
			var response = await _client.GetAsync($"products/{id}");

			if (response.IsSuccessStatusCode)
			{
				var responseMessage = await response.Content.ReadAsStringAsync();
				var responseData = JsonConvert.DeserializeObject<Returns>(responseMessage);
				
				Assert.NotNull(responseData);
				Assert.True( responseData.Success);
				
				var product = JsonConvert.DeserializeObject<ProductModel>(responseData.Data.ToString());
				
				Assert.Equal("Macbook Pro", product.Name);
			}
		}
	}
}
