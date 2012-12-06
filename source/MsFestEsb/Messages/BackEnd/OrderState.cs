using System;
using System.Collections.Generic;

namespace Messages.BackEnd
{
	public class OrderState
	{
		public OrderState()
		{
			Products = new List<ProductAddedOnOrder>();
		}

		public List<ProductAddedOnOrder> Products { get; set; }

		public bool IsComplete
		{
			get { return Products.Count == Items; }
		}

		public int Items { get; set; }

		public void AddProduct(ProductAddedOnOrder message)
		{
			Products.Add(message);
		}
	}
}