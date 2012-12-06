using System;
using System.Collections.Generic;

namespace Messages.BackEnd
{
	[Serializable]
	public class OrderCreated: BaseMessage
	{
		public IList<OrderItem> OrderItems { get; set; }
	}

}