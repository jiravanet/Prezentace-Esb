﻿using System;
using Rhino.ServiceBus.Sagas;

namespace Messages.BackEnd
{
	[Serializable]
	public class OrderSplitted : BaseMessage, ISagaMessage
	{
		public int Length { get; set; }

		public OrderSplitted()
		{
			Length = 0;
		}

		public OrderSplitted(Guid id, int length)
		{
			Id = id;
			Length = length;
		}

		public Guid CorrelationId { get; set; }
	}
}