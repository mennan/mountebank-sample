using System;

namespace Ecommerce.API
{
	public class ProductModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}