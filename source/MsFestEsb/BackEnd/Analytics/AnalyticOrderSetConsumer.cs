﻿using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Analytics
{
	public class AnalyticOrderSetConsumer : ConsumerOf<OrderSet>
	{
		readonly IAnalyticSource source;

		public AnalyticOrderSetConsumer(IAnalyticSource source)
		{
			this.source = source;
		}


		public void Consume(OrderSet message)
		{
			var data = new AnalyticOrderSet() {CustomerName = message.CustomerName, ProductCount = message.OrderItems.Count};
			source.Add(data);
		}
	}
}