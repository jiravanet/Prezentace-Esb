using System;
using System.Diagnostics;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class OrderCompletedConsumer: ConsumerOf<OrderCompleted>
	{
		public void Consume(OrderCompleted message)
		{
			//TODO: do the work needed when order is completed
			Debug.WriteLine(message.CorrelationId, "OrderCompleted");

			Debug.WriteLine(text, "OrderCompleted");
		}
	}
}