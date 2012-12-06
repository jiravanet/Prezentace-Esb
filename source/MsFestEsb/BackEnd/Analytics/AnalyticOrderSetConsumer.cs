﻿using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Analytics
{
	public class AnalyticOrderSetConsumer : ConsumerOf<OrderSet>
	{
		private readonly IAnalyticSource _source;

		public AnalyticOrderSetConsumer(IAnalyticSource source)
		{
			_source = source;
		}


		public void Consume(OrderSet message)
		{
			var data = new AnalyticOrderSet() {CustomerName = message.CustomerName, ProductCount = message.OrderItems.Count};
			_source.Add(data);
		}
	}
}