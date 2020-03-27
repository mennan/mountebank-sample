using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		public static List<ProductModel> Products = new List<ProductModel>
		{

		};

		[HttpGet]
		public Returns Get()
		{
			return new Returns
			{
				Data = Products,
				Success = true
			};
		}

		[HttpGet("{id}")]
		public Returns Get(Guid id)
		{
			var product = Products.FirstOrDefault(a => a.Id == id);

			return new Returns
			{
				Data = product,
				Success = true
			};
		}

		[HttpPost]
		public Returns Post([FromBody]ProductModel model)
		{
			if (string.IsNullOrEmpty(model.Name))
			{
				return new Returns
				{
					Success = false,
					Message = "Invalid data"
				};
			}

			Products.Add(model);

			return new Returns
			{
				Success = true,
				Data = model
			};
		}


	}
}
