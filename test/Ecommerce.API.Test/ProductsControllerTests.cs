using System;
using Xunit;
using Ecommerce.API;
using Ecommerce.API.Controllers;

namespace Ecommerce.API.Test
{
	public class ProductsControllerTest
	{
		[Fact]
		public void Get_ReturnsAllProducts()
		{
			var controller = new ProductsController();
			var products = controller.Get();

			Assert.NotNull(products);
			Assert.NotNull(products.Data);
			Assert.True(products.Success);
		}

		[Theory]
		[InlineData("35DEEAFA-FAB8-42CB-919A-A1549EFF41B9", "Macbook Pro", 10, "Macbook Pro")]
		[InlineData("8EBE8689-D41D-4613-81BD-2D7DB6EA2B6E", "AirPods Pro", 10, "AirPods Pro")]
		public void Post_ReturnsAddedProduct(string productId, string name, decimal price, string expectedName)
		{
		    var controller = new ProductsController();
		    var response = controller.Post(new ProductModel
		    {
			    Id = Guid.Parse(productId),
			    Name = name,
			    Price = price
		    });
		    
		    Assert.NotNull(response);
		    Assert.NotNull(response.Data);

		    var data = (ProductModel) response.Data;
		    
		    Assert.True(response.Success);
		    Assert.Equal(expectedName, data.Name);
		}
	}
}
