using System.Collections.Generic;
using System.Linq;
using BackEnd.Interfaces;
using Messages.BackEnd;

namespace BackEnd.Workers
{
	public class OrderProcessor: IOrderSplitter, IOrderCompleter
	{
		public ProcessProductRequest[] Split(OrderCreated message)
		{
			var parts = from m in message.OrderItems
			            select new ProcessProductRequest() {OrderId = message.Id, Pieces = m.Pieces, ProductId = m.Product};
			return parts.ToArray();
		}

		public OrderCompleted Complete(List<ProductAddedOnOrder> products)
		{
			var id = products.First().OrderId;
			return new OrderCompleted() {OrderId = id};
		}
	}
}