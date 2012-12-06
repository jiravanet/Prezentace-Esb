using System;
using System.Collections.Generic;

namespace Messages.BackEnd
{
	public class OrderSet: BaseMessage
	{
		public string CustomerName { get; set; }

		public DateTime Date { get; set; }

		public IList<OrderItem> OrderItems { get; set; }

	}

	[Serializable]
	public class OrderItem
	{
		public int Product { get; set; }

		public int Pieces { get; set; }
	}
}